using MealWiseAPI.Models;

namespace MealWiseAPI.DTOs;

public class ShoppingListCreateDTO
{
    public string Name { get; set; }
    public ShoppingListStatus Status { get; set; }
}
