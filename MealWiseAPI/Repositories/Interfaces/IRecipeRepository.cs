using MealWiseAPI.Models;

namespace MealWiseAPI.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int id);
    Task<Recipe> CreateRecipeAsync(Recipe recipe);
    Task AddIngredientGroupsAsync(IEnumerable<IngredientGroup> ingredientGroups);
    Task<Recipe> UpdateRecipeAsync(Recipe recipe);
    Task DeleteRecipeAsync(int id);

}
