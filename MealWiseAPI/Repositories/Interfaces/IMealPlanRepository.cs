using MealWise.Models;
using MealWiseAPI.DTOs;

namespace MealWise.Repositories.Interfaces;

public interface IMealPlanRepository
{
    Task<IEnumerable<MealPlanDTO>> GetMealPlansAsync();
    Task<MealPlanDTO> GetMealPlanByIdAsync(int id);
    Task<MealPlanDTO> CreateMealPlanAsync(MealPlanCreateDTO mealPlanDTO);
    Task<MealPlanDTO> UpdateMealPlanAsync(MealPlan mealPlan);
    Task DeleteMealPlanAsync(int id);
}
