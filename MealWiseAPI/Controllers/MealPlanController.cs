using MealWise.Models;
using MealWise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWise.Controllers;

[ApiController]
[Route("api/mealplans")]
public class MealPlanController : ControllerBase
{
    private readonly IMealPlanService _mealPlanService;
    public MealPlanController(IMealPlanService mealPlanService)
    {
        _mealPlanService = mealPlanService;
    }
    [HttpGet]
    public async Task<IEnumerable<MealPlan>> GetMealPlans()
    {
        return await _mealPlanService.GetMealPlansAsync();
    }
    [HttpGet("{id}")]
    public async Task<MealPlan> GetMealPlanById(int id)
    {
        return await _mealPlanService.GetMealPlanByIdAsync(id);
    }
    [HttpPost]
    public async Task<MealPlan> CreateMealPlan([FromBody] MealPlan mealPlan)
    {
        return await _mealPlanService.CreateMealPlanAsync(mealPlan);
    }
    [HttpPut]
    public async Task<MealPlan> UpdateMealPlan([FromBody] MealPlan mealPlan)
    {
        return await _mealPlanService.UpdateMealPlanAsync(mealPlan);
    }
    [HttpDelete("{id}")]
    public async Task DeleteMealPlan(int id)
    {
        await _mealPlanService.DeleteMealPlanAsync(id);
    }
}
