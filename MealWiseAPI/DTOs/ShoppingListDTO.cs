namespace MealWiseAPI.DTOs;

public class ShoppingListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly CreatedAt { get; set; }
    public List<ShoppingListItemDTO> Items { get; set; } = new();
}
