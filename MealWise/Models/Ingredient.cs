using System.ComponentModel.DataAnnotations;

namespace MealWise.Models;

public class Ingredient
{
    public int Id { get; set; }
    [Required]
    [MaxLength(70)]
    public string Name { get; set; }
    [Required]
    public string UnitType { get; set; }
}
