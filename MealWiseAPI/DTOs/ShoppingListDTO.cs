namespace MealWiseAPI.DTOs;

public class ShoppingListDTO
{
    public int Id { get; set; }
    public int MealPlanId { get; set; }
    public string Status { get; set; }
    public List<ShoppingListItemDTO> Items { get; set; } = new();
}
