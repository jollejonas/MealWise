using System.ComponentModel.DataAnnotations.Schema;

namespace MealWise.Models;

public enum MealType
{
    Breakfast,
    Lunch,
    Dinner,
    Snack
}

public class MealPlanRecipe
{
    [ForeignKey("MealPlanId")]
    public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; }
    [ForeignKey("RecipeId")]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public DateOnly Date { get; set; }
    public string MealType { get; set; }
    public int ServingsOverride { get; set; }
}
