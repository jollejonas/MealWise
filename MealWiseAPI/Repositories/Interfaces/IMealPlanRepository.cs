using MealWise.Models;

namespace MealWise.Repositories.Interfaces;

public interface IMealPlanRepository
{
    Task<IEnumerable<MealPlan>> GetMealPlansAsync();
    Task<MealPlan> GetMealPlanByIdAsync(int id);
    Task<MealPlan> CreateMealPlanAsync(MealPlan mealPlan);
    Task<MealPlan> UpdateMealPlanAsync(MealPlan mealPlan);
    Task DeleteMealPlanAsync(int id);
}
