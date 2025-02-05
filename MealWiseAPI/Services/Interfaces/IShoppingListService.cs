using MealWise.Models;

namespace MealWise.Services.Interfaces;

public interface IShoppingListService
{
    Task<IEnumerable<ShoppingList>> GetShoppingListsAsync();
    Task<ShoppingList> GetShoppingListByIdAsync(int id);
    Task<ShoppingList> CreateShoppingListAsync(int mealPlanId);
    Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
    Task DeleteShoppingListAsync(int id);
}
