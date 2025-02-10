using MealWiseAPI.DTOs;
using MealWiseAPI.Models;

namespace MealWiseAPI.Repositories.Interfaces;

public interface IShoppingListRepository
{
    Task<bool> IngredientExistsAsync(int ingredientId);
    Task<IEnumerable<ShoppingList>> GetShoppingListsAsync();
    Task<ShoppingListDTO> GetShoppingListByIdAsync(int id);
    Task<ShoppingListDTO> CreateShoppingListAsync(int mealPlanId);
    Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
    Task DeleteShoppingListAsync(int id);
}
