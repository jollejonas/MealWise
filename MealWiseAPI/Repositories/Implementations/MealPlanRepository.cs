using MealWise.Data;
using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWiseAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealWise.Repositories.Implementations;

public class MealPlanRepository : IMealPlanRepository
{
    private readonly MealWiseContext _context;
    public MealPlanRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MealPlanDTO>> GetMealPlansAsync()
    {
        return await _context.MealPlans
            .Include(mp => mp.MealPlanRecipes)
            .Select(mp => new MealPlanDTO
            {
                Id = mp.Id,
                Name = mp.Name,
                StartDate = mp.StartDate,
                EndDate = mp.EndDate,
                MealPlanRecipes = mp.MealPlanRecipes.Select(mpr => new MealPlanRecipeDTO
                {
                    RecipeId = mpr.Recipe.Id,
                    Recipe = new RecipeDTO
                    {
                        Id = mpr.Recipe.Id,
                        Title = mpr.Recipe.Title,
                        Servings = mpr.Recipe.Servings,
                    },
                    Date = mpr.Date,
                    MealType = mpr.MealType,
                    ServingsOverride = mpr.ServingsOverride,
                }).ToList()
            })
            .ToListAsync();
    }
    public async Task<MealPlanDTO> GetMealPlanByIdAsync(int id)
    {
        var mealPlan = await _context.MealPlans
            .Include(mp => mp.MealPlanRecipes)
            .ThenInclude(mpr => mpr.Recipe)
            .FirstOrDefaultAsync(mp => mp.Id == id);

        if (mealPlan == null)
        {
            return null;
        }

        return new MealPlanDTO
        {
            Id = mealPlan.Id,
            Name = mealPlan.Name,
            StartDate = mealPlan.StartDate,
            EndDate = mealPlan.EndDate,
            MealPlanRecipes = mealPlan.MealPlanRecipes.Select(mpr => new MealPlanRecipeDTO
            {
                Recipe = new RecipeDTO
                {
                    Id = mpr.Recipe.Id,
                    Title = mpr.Recipe.Title,
                    Servings = mpr.Recipe.Servings,
                },
                Date = mpr.Date,
                MealType = mpr.MealType,
                ServingsOverride = mpr.ServingsOverride,
            }).ToList()
        };
    }

    public async Task<MealPlanDTO> CreateMealPlanAsync(MealPlanCreateDTO mealPlanDTO)
    {
        var mealPlan = new MealPlan
        {
            Name = mealPlanDTO.Name,
            StartDate = mealPlanDTO.StartDate,
            EndDate = mealPlanDTO.EndDate,
            MealPlanRecipes = mealPlanDTO.MealPlanRecipes.Select(mpr => new MealPlanRecipe
            {
                Date = mpr.Date,
                MealType = mpr.MealType,
                ServingsOverride = mpr.ServingsOverride,
                Recipe = _context.Recipes.FirstOrDefault(r => r.Id == mpr.RecipeId)
                    ?? throw new ArgumentException($"Recipe with ID {mpr.RecipeId} not found.")
            }).ToList()
        };

        _context.MealPlans.Add(mealPlan);
        await _context.SaveChangesAsync();

        return await GetMealPlanByIdAsync(mealPlan.Id);
    }

    public async Task<MealPlanDTO> UpdateMealPlanAsync(MealPlan mealPlan)
    {
        _context.MealPlans.Update(mealPlan);
        await _context.SaveChangesAsync();
        return await GetMealPlanByIdAsync(mealPlan.Id);
    }
    public async Task DeleteMealPlanAsync(int id)
    {
        var mealPlan = await _context.MealPlans.FindAsync(id);
        _context.MealPlans.Remove(mealPlan);
        await _context.SaveChangesAsync();
    }
}
