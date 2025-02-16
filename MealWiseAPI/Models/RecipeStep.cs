using System.ComponentModel.DataAnnotations.Schema;

namespace MealWiseAPI.Models;

public class RecipeStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }
    [ForeignKey("IngredientGroup")]
    public int IngredientGroupId { get; set; }
    public IngredientGroup? IngredientGroup { get; set; }
}
