using System.ComponentModel.DataAnnotations;

namespace MealWise.Models;

public enum ShoppingListStatus
{
    Active,
    Archived
}

public class ShoppingList
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    [Required]
    public string Status { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
}
