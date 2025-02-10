using MealWiseAPI.DTOs;
using MealWiseAPI.Models;
using MealWiseAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWiseAPI.Controllers;

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
    public async Task<IActionResult> GetMealPlans()
    {
        var mealPlans = await _mealPlanService.GetMealPlansAsync();
        return Ok(mealPlans);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMealPlanById(int id)
    {
        var mealPlan = await _mealPlanService.GetMealPlanByIdAsync(id);
        if (mealPlan == null)
        {
            return NotFound();
        }
        return Ok(mealPlan);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMealPlan([FromBody] MealPlanCreateDTO mealPlanDTO)
    {
        var mealPlan = await _mealPlanService.CreateMealPlanAsync(mealPlanDTO);
        return CreatedAtAction(nameof(GetMealPlanById), new { id = mealPlan.Id }, mealPlan);
    }
    [HttpPut]
    public async Task<MealPlanDTO> UpdateMealPlan([FromBody] MealPlan mealPlan)
    {
        return await _mealPlanService.UpdateMealPlanAsync(mealPlan);
    }
    [HttpDelete("{id}")]
    public async Task DeleteMealPlan(int id)
    {
        await _mealPlanService.DeleteMealPlanAsync(id);
    }
}
