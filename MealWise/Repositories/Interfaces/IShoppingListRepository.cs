using MealWise.Models;

namespace MealWise.Repositories.Interfaces;

public interface IShoppingListRepository
{
    Task<IEnumerable<ShoppingList>> GetShoppingListsAsync();
    Task<ShoppingList> GetShoppingListByIdAsync(int id);
    Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);
    Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
    Task DeleteShoppingListAsync(int id);
}
