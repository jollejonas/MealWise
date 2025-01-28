using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWise.Services.Interfaces;


namespace MealWise.Services.Implementations;

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
        foreach (var recipeIngredient in recipe.RecipeIngredients)
        {
            if (recipeIngredient.Ingredient == null)
            {
                throw new ArgumentNullException(nameof(recipeIngredient.Ingredient), "Ingredient cannot be null");
            }

            var ingredient = await _ingredientService.GetOrCreateIngredientAsync(
                recipeIngredient.Ingredient.Name,
                recipeIngredient.Ingredient.UnitType ?? recipeIngredient.UnitOverride
            );

            recipeIngredient.IngredientId = ingredient.Id;
            recipeIngredient.RecipeId = recipe.Id;
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
