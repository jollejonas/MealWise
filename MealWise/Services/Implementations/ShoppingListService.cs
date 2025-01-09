using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWise.Services.Interfaces;


namespace MealWise.Services.Implementations;

public class ShoppingListService : IShoppingListService
{
    private readonly IShoppingListRepository _shoppingListRepository;
    public ShoppingListService(IShoppingListRepository shoppingListRepository)
    {
        _shoppingListRepository = shoppingListRepository;
    }
    public async Task<IEnumerable<ShoppingList>> GetShoppingListsAsync()
    {
        return await _shoppingListRepository.GetShoppingListsAsync();
    }
    public async Task<ShoppingList> GetShoppingListByIdAsync(int id)
    {
        return await _shoppingListRepository.GetShoppingListByIdAsync(id);
    }
    public async Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList)
    {
        return await _shoppingListRepository.CreateShoppingListAsync(shoppingList);
    }
    public async Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList)
    {
        return await _shoppingListRepository.UpdateShoppingListAsync(shoppingList);
    }
    public async Task DeleteShoppingListAsync(int id)
    {
        await _shoppingListRepository.DeleteShoppingListAsync(id);
    }
}
