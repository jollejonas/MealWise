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
    public async Task<bool> IngredientExistsAsync(int ingredientId)
    {
        return await _context.Ingredients.AnyAsync(i => i.Id == ingredientId);
    }

    public async Task<IEnumerable<ShoppingList>> GetShoppingListsAsync()
    {
        return await _context.ShoppingLists.ToListAsync();
    }

    public async Task<MealPlan?> GetMealPlanWithRecipesAsync(int mealPlanId)
    {
        return await _context.MealPlans
                    .Include(mp => mp.MealPlanRecipes)
                    .ThenInclude(mpr => mpr.Recipe)
                    .ThenInclude(ri => ri.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                    .FirstOrDefaultAsync(mp => mp.Id == mealPlanId);
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
