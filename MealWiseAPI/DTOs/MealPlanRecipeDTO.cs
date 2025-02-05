namespace MealWiseAPI.DTOs;

public class MealPlanRecipeDTO
{
    public int RecipeId { get; set; }
    public DateOnly Date { get; set; }
    public string MealType { get; set; }
    public int ServingsOverride { get; set; }
}
