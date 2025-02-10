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
        foreach (var ingredientGroup in recipe.IngredientGroups)
        {
            foreach (var ingredient in ingredientGroup.IngredientGroupIngredients)
            {
                if (ingredient.Ingredient == null)
                {
                    throw new ArgumentNullException(nameof(ingredient.Ingredient), "Ingredient cannot be null");
                }
                var newIngredient = await _ingredientService.GetOrCreateIngredientAsync(
                    ingredient.Ingredient.Name,
                    ingredient.Ingredient.UnitType ?? ingredient.UnitOverride
                );
                ingredient.IngredientId = newIngredient.Id;
            }
        }

        recipe.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        recipe.UpdatedAt = DateOnly.FromDateTime(DateTime.Now);

        await _recipeRepository.CreateRecipeAsync(recipe);

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
