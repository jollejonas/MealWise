using MealWise.Models;

namespace MealWise.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int id);
    Task<Recipe> CreateRecipeAsync(Recipe recipe);
    Task<Recipe> UpdateRecipeAsync(Recipe recipe);
    Task DeleteRecipeAsync(int id);
}
