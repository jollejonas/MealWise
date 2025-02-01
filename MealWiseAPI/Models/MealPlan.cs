using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealWise.Models;

public class MealPlan
{
    public int Id { get; set; }
    [Required]
    [MaxLength(70)]
    public string Name { get; set; }
    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public ICollection<MealPlanRecipe> MealPlanRecipes { get; set; }
}
