namespace MealWise.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public string Instructions { get; set; }
    public int Servings { get; set; }
    public string ImageUrl { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
