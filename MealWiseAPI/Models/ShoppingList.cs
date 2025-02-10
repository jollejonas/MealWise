using System.ComponentModel.DataAnnotations.Schema;

namespace MealWiseAPI.Models;

public enum ShoppingListStatus
{
    Active,
    Archived
}

public class ShoppingList
{
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    public string Name { get; set; }
    public ShoppingListStatus Status { get; set; } = ShoppingListStatus.Active;
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }

    public List<ShoppingListItem> Items { get; set; }
}
