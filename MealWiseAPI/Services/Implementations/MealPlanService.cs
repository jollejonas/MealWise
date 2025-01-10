using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWise.Services.Interfaces;


namespace MealWise.Services.Implementations;

public class MealPlanService : IMealPlanService
{
    private readonly IMealPlanRepository _mealPlanRepository;
    public MealPlanService(IMealPlanRepository mealPlanRepository)
    {
        _mealPlanRepository = mealPlanRepository;
    }
    public async Task<IEnumerable<MealPlan>> GetMealPlansAsync()
    {
        return await _mealPlanRepository.GetMealPlansAsync();
    }
    public async Task<MealPlan> GetMealPlanByIdAsync(int id)
    {
        return await _mealPlanRepository.GetMealPlanByIdAsync(id);
    }
    public async Task<MealPlan> CreateMealPlanAsync(MealPlan mealPlan)
    {
        return await _mealPlanRepository.CreateMealPlanAsync(mealPlan);
    }
    public async Task<MealPlan> UpdateMealPlanAsync(MealPlan mealPlan)
    {
        return await _mealPlanRepository.UpdateMealPlanAsync(mealPlan);
    }
    public async Task DeleteMealPlanAsync(int id)
    {
        await _mealPlanRepository.DeleteMealPlanAsync(id);
    }
}
