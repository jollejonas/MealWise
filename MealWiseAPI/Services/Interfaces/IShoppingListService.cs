using MealWise.Models;
using MealWiseAPI.DTOs;

namespace MealWise.Services.Interfaces;

public interface IShoppingListService
{
    Task<IEnumerable<ShoppingList>> GetShoppingListsAsync();
    Task<ShoppingListDTO> GetShoppingListByIdAsync(int id);
    Task<ShoppingListDTO> CreateShoppingListAsync(int mealPlanId);
    Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
    Task DeleteShoppingListAsync(int id);
}
