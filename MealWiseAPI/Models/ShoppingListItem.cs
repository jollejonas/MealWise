using System.ComponentModel.DataAnnotations;

namespace MealWise.Models;

public enum ShoppingListSource
{
    Manual,
    MealPlan
}

public class ShoppingListItem
{
    public int Id { get; set; }
    public int ShoppingListId { get; set; }
    public ShoppingList? ShoppingList { get; set; }
    public int? MealPlanId { get; set; }
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
    [Required]
    public int Quantity { get; set; }
    public string UnitOverride { get; set; } = null;
    public bool Checked { get; set; } = false;

    public ShoppingListSource Source { get; set; } = ShoppingListSource.Manual;
}
