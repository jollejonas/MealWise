namespace MealWiseAPI.DTOs;

public class MealPlanCreateDTO
{
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<MealPlanRecipeDTO> MealPlanRecipes { get; set; }
}
