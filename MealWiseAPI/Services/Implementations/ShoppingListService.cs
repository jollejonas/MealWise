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
    public async Task<ShoppingList?> CreateShoppingListAsync(int mealPlanId)
    {
        var mealPlan = await _shoppingListRepository.GetMealPlanWithRecipesAsync(mealPlanId);

        if (mealPlan == null)
        {
            return null;
        }

        var shoppingList = new ShoppingList
        {
            Status = ShoppingListStatus.Active,
            CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow),
            Items = new List<ShoppingListItem>()
        };

        var ingredientDictionary = new Dictionary<int, (double quantity, string unit)>();

        foreach (var mealRecipe in mealPlan.MealPlanRecipes)
        {
            foreach (var ingredient in mealRecipe.Recipe.RecipeIngredients)
            {
                // **TJEK OM INGREDIENT FINDES**
                var exists = await _shoppingListRepository.IngredientExistsAsync(ingredient.IngredientId);
                if (!exists)
                {
                    Console.WriteLine($"Advarsel: IngredientId {ingredient.IngredientId} findes ikke i databasen.");
                    continue; // Spring ingrediensen over
                }

                if (ingredientDictionary.ContainsKey(ingredient.IngredientId))
                {
                    ingredientDictionary[ingredient.IngredientId] = (
                        ingredientDictionary[ingredient.IngredientId].quantity + ingredient.Quantity,
                        ingredient.UnitOverride ?? ingredient.Ingredient.UnitType
                    );
                }
                else
                {
                    ingredientDictionary[ingredient.IngredientId] = (ingredient.Quantity, ingredient.UnitOverride ?? ingredient.Ingredient.UnitType);
                }
            }
        }

        shoppingList.Items = ingredientDictionary
            .Select(i => new ShoppingListItem
            {
                IngredientId = i.Key,
                Quantity = (int)Math.Round(i.Value.quantity),
                UnitOverride = i.Value.unit,
                Checked = false
            })
            .ToList();

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
