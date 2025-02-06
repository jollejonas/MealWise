namespace MealWiseAPI.DTOs;

public class ShoppingListItemDTO
{
    public int Id { get; set; }
    public string IngredientName { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }
    public bool Checked { get; set; }
}
