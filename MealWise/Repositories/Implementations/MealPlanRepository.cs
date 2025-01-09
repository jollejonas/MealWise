using MealWise.Data;
using MealWise.Models;
using MealWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealWise.Repositories.Implementations;

public class MealPlanRepository : IMealPlanRepository
{
    private readonly MealWiseContext _context;
    public MealPlanRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MealPlan>> GetMealPlansAsync()
    {
        return await _context.MealPlans.ToListAsync();
    }
    public async Task<MealPlan> GetMealPlanByIdAsync(int id)
    {
        return await _context.MealPlans.FindAsync(id);
    }
    public async Task<MealPlan> CreateMealPlanAsync(MealPlan mealPlan)
    {
        _context.MealPlans.Add(mealPlan);
        await _context.SaveChangesAsync();
        return mealPlan;
    }
    public async Task<MealPlan> UpdateMealPlanAsync(MealPlan mealPlan)
    {
        _context.MealPlans.Update(mealPlan);
        await _context.SaveChangesAsync();
        return mealPlan;
    }
    public async Task DeleteMealPlanAsync(int id)
    {
        var mealPlan = await _context.MealPlans.FindAsync(id);
        _context.MealPlans.Remove(mealPlan);
        await _context.SaveChangesAsync();
    }
}
