using MealWise.Data;
using MealWise.Models;
using MealWise.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealWise.Repositories.Implementations;

public class RecipeRepository : IRecipeRepository
{
    private readonly MealWiseContext _context;
    public RecipeRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Recipe>> GetRecipesAsync()
    {
        return await _context.Recipes.ToListAsync();
    }
    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return await _context.Recipes.FindAsync(id);
    }
    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }
    public async Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
        return recipe;
    }
    public async Task DeleteRecipeAsync(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}
