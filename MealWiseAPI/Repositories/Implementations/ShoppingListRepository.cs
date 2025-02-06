using MealWise.Data;
using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWiseAPI.DTOs;
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

    public async Task<ShoppingListDTO> GetShoppingListByIdAsync(int id)
    {
        var shoppingList = await _context.ShoppingLists
            .Include(sl => sl.Items)
            .ThenInclude(sli => sli.Ingredient) // Hent ingrediensdata
            .FirstOrDefaultAsync(sl => sl.Id == id);

        if (shoppingList == null)
        {
            return null;
        }

        return new ShoppingListDTO
        {
            Id = shoppingList.Id,
            Name = $"Shopping List - {shoppingList.CreatedAt}",
            CreatedAt = shoppingList.CreatedAt,
            Items = shoppingList.Items.Select(sli => new ShoppingListItemDTO
            {
                Id = sli.Id,
                IngredientName = sli.Ingredient.Name,
                Quantity = sli.Quantity,
                Unit = sli.UnitOverride ?? sli.Ingredient.UnitType,
                Checked = sli.Checked
            }).ToList()
        };
    }
    public async Task<ShoppingListDTO> CreateShoppingListAsync(int mealPlanId)
    {
        var mealPlan = await _context.MealPlans
            .Include(mp => mp.MealPlanRecipes)
                .ThenInclude(mpr => mpr.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
            .FirstOrDefaultAsync(mp => mp.Id == mealPlanId);

        if (mealPlan == null)
        {
            return null;
        }

        var shoppingList = new ShoppingList
        {
            Name = $"Indkøbsliste til madplanen: {mealPlan.Name}",
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            Status = ShoppingListStatus.Active,
            Items = new List<ShoppingListItem>()
        };

        var ingredientDict = new Dictionary<int, (double Quantity, string Unit)>();

        foreach (var mealRecipe in mealPlan.MealPlanRecipes)
        {
            foreach (var ingredient in mealRecipe.Recipe.RecipeIngredients)
            {
                if (ingredient.Ingredient == null)
                {
                    continue;
                }

                var exists = await IngredientExistsAsync(ingredient.IngredientId);
                if (!exists)
                {
                    Console.WriteLine($"⚠️ Advarsel: IngredientId {ingredient.IngredientId} findes ikke i databasen.");
                    continue;
                }

                if (ingredientDict.ContainsKey(ingredient.IngredientId))
                {
                    ingredientDict[ingredient.IngredientId] = (
                        ingredientDict[ingredient.IngredientId].Quantity + ingredient.Quantity,
                        ingredient.UnitOverride ?? ingredient.Ingredient.UnitType
                    );
                }
                else
                {
                    ingredientDict[ingredient.IngredientId] = (ingredient.Quantity, ingredient.UnitOverride ?? ingredient.Ingredient.UnitType);
                }
            }
        }

        shoppingList.Items = ingredientDict
            .Select(i => new ShoppingListItem
            {
                IngredientId = i.Key,
                Quantity = (int)i.Value.Quantity,
                UnitOverride = i.Value.Unit,
                Checked = false
            })
            .ToList();

        _context.ShoppingLists.Add(shoppingList);
        await _context.SaveChangesAsync();

        return await GetShoppingListByIdAsync(shoppingList.Id);
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
