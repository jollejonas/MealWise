using System.ComponentModel.DataAnnotations.Schema;

namespace MealWiseAPI.Models;

public class IngredientGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Recipe")]
    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    public ICollection<IngredientGroupIngredient> IngredientGroupIngredients { get; set; } = new List<IngredientGroupIngredient>();
    public ICollection<RecipeStep> Steps { get; set; } = new List<RecipeStep>();
}
