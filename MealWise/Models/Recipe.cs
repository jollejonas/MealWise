using System.ComponentModel.DataAnnotations;

namespace MealWise.Models;

public class Recipe
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Range(0, 15000)]
    public int PrepTime { get; set; }
    [Range(0, 15000)]
    public int CookTime { get; set; }
    [MaxLength(500)]
    public string Instructions { get; set; }
    [Required]
    [Range(0, 1000)]
    public int Servings { get; set; }
    public string ImageUrl { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }

}
