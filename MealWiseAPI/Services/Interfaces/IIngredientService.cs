using MealWise.Models;

namespace MealWise.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
    Task DeleteIngredientAsync(int id);
}
