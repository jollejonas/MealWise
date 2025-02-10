using MealWiseAPI.DTOs;
using MealWiseAPI.Models;

namespace MealWiseAPI.Services.Interfaces;

public interface IMealPlanService
{
    Task<IEnumerable<MealPlanDTO>> GetMealPlansAsync();
    Task<MealPlanDTO> GetMealPlanByIdAsync(int id);
    Task<MealPlanDTO> CreateMealPlanAsync(MealPlanCreateDTO mealPlanDTO);
    Task<MealPlanDTO> UpdateMealPlanAsync(MealPlan mealPlan);
    Task DeleteMealPlanAsync(int id);
}
