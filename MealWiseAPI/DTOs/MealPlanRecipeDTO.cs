using MealWise.Models;

namespace MealWiseAPI.DTOs;

public class MealPlanRecipeDTO
{
    public RecipeDTO Recipe { get; set; }
    public DateOnly Date { get; set; }
    public MealType MealType { get; set; }
    public int ServingsOverride { get; set; }
}
