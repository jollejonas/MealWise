using MealWise.Models;

namespace MealWise.Repositories.Interfaces;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<Ingredient> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
    Task DeleteIngredientAsync(int id);
}
