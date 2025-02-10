using MealWiseAPI.Models;

namespace MealWiseAPI.Repositories.Interfaces;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
    Task DeleteIngredientAsync(int id);
    Task<Ingredient> GetOrCreateIngredientAsync(string name, string unitType);
}
