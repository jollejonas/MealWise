using MealWiseAPI.DTOs;
using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using MealWiseAPI.Services.Interfaces;


namespace MealWiseAPI.Services.Implementations;

public class MealPlanService : IMealPlanService
{
    private readonly IMealPlanRepository _mealPlanRepository;
    public MealPlanService(IMealPlanRepository mealPlanRepository)
    {
        _mealPlanRepository = mealPlanRepository;
    }
    public async Task<IEnumerable<MealPlanDTO>> GetMealPlansAsync()
    {
        return await _mealPlanRepository.GetMealPlansAsync();
    }
    public async Task<MealPlanDTO> GetMealPlanByIdAsync(int id)
    {
        return await _mealPlanRepository.GetMealPlanByIdAsync(id);
    }
    public async Task<MealPlanDTO> CreateMealPlanAsync(MealPlanCreateDTO mealPlanDTO)
    {
        return await _mealPlanRepository.CreateMealPlanAsync(mealPlanDTO);
    }
    public async Task<MealPlanDTO> UpdateMealPlanAsync(MealPlan mealPlan)
    {
        return await _mealPlanRepository.UpdateMealPlanAsync(mealPlan);
    }
    public async Task DeleteMealPlanAsync(int id)
    {
        await _mealPlanRepository.DeleteMealPlanAsync(id);
    }
}
