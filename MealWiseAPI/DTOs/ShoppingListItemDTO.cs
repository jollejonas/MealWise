namespace MealWiseAPI.DTOs;

public class ShoppingListItemDTO
{
    public int id { get; set; }
    public int IngredientId { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }
    public bool Checked { get; set; }
}
