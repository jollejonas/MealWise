using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using MealWiseAPI.Services.Interfaces;


namespace MealWiseAPI.Services.Implementations;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientService _ingredientService;
    public RecipeService(IRecipeRepository recipeRepository, IIngredientService ingredientService)
    {
        _recipeRepository = recipeRepository;
        _ingredientService = ingredientService;
    }
    public async Task<IEnumerable<Recipe>> GetRecipesAsync()
    {
        return await _recipeRepository.GetRecipesAsync();
    }
    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return await _recipeRepository.GetRecipeByIdAsync(id);
    }
    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        recipe.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        recipe.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

        recipe = await _recipeRepository.CreateRecipeAsync(recipe);

        foreach (var ingredientGroup in recipe.IngredientGroups)
        {
            ingredientGroup.Id = 0;
            ingredientGroup.RecipeId = recipe.Id;

            foreach (var ingredient in ingredientGroup.IngredientGroupIngredients)
            {
                if (!string.IsNullOrWhiteSpace(ingredient.Ingredient.Name))
                {
                    var existingIngredient = await _ingredientService.GetOrCreateIngredientAsync(ingredient.Ingredient.Name, ingredient.Ingredient.UnitType);

                    ingredient.IngredientId = existingIngredient.Id;
                    ingredient.Ingredient = existingIngredient;
                }

                if (ingredient.Ingredient == null)
                {
                    throw new ArgumentException($"Ingredient is missing for IngredientId {ingredient.IngredientId}");
                }
            }
        }

        await _recipeRepository.AddIngredientGroupsAsync(recipe.IngredientGroups);

        foreach (var ingredientGroup in recipe.IngredientGroups)
        {
            foreach (var step in ingredientGroup.Steps)
            {
                step.IngredientGroupId = ingredientGroup.Id;
            }
        }

        await _recipeRepository.UpdateRecipeAsync(recipe);


        return recipe;
    }
    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        return await _recipeRepository.UpdateRecipeAsync(recipe);
    }
    public async Task DeleteRecipeAsync(int id)
    {
        await _recipeRepository.DeleteRecipeAsync(id);
    }
}
