using MealWise.Models;

namespace MealWiseAPI.DTOs;

public class MealPlanRecipeCreateDTO
{
    public int RecipeId { get; set; }
    public DateOnly Date { get; set; }
    public MealType MealType { get; set; }
    public int ServingsOverride { get; set; }
}
