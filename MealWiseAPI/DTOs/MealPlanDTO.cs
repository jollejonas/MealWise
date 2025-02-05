namespace MealWiseAPI.DTOs;

public class MealPlanDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<MealPlanRecipeDTO> MealPlanRecipes { get; set; }
}
