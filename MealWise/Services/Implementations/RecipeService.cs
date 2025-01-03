using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWise.Services.Interfaces;


namespace MealWise.Services.Implementations;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
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
        return await _recipeRepository.CreateRecipeAsync(recipe);
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
