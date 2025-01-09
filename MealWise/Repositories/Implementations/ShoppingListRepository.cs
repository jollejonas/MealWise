using MealWise.Data;
using MealWise.Models;
using MealWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealWise.Repositories.Implementations;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly MealWiseContext _context;
    public ShoppingListRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ShoppingList>> GetShoppingListsAsync()
    {
        return await _context.ShoppingLists.ToListAsync();
    }
    public async Task<ShoppingList> GetShoppingListByIdAsync(int id)
    {
        return await _context.ShoppingLists.FindAsync(id);
    }
    public async Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList)
    {
        _context.ShoppingLists.Add(shoppingList);
        await _context.SaveChangesAsync();
        return shoppingList;
    }
    public async Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList)
    {
        _context.ShoppingLists.Update(shoppingList);
        await _context.SaveChangesAsync();
        return shoppingList;
    }
    public async Task DeleteShoppingListAsync(int id)
    {
        var shoppingList = await _context.ShoppingLists.FindAsync(id);
        _context.ShoppingLists.Remove(shoppingList);
        await _context.SaveChangesAsync();
    }
}
