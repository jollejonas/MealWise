using MealWiseAPI.Models;

namespace MealWiseAPI.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
    Task DeleteIngredientAsync(int id);
    Task<Ingredient> GetOrCreateIngredientAsync(string name, string unitType);
}
