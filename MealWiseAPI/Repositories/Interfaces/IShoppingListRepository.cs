using MealWise.Models;

namespace MealWise.Repositories.Interfaces;

public interface IShoppingListRepository
{
    Task<bool> IngredientExistsAsync(int ingredientId);
    Task<IEnumerable<ShoppingList>> GetShoppingListsAsync();
    Task<MealPlan?> GetMealPlanWithRecipesAsync(int mealPlanId);
    Task<ShoppingList> GetShoppingListByIdAsync(int id);
    Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);
    Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
    Task DeleteShoppingListAsync(int id);
}
