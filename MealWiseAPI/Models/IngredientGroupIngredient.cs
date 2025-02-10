namespace MealWiseAPI.Models;

public class IngredientGroupIngredient
{
    public int Id { get; set; }
    public double Quantity { get; set; }
    public string? UnitOverride { get; set; } = null;
    public int IngredientGroupId { get; set; }
    public IngredientGroup? IngredientGroup { get; set; }
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }

}
