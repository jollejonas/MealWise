using MealWiseAPI.Data;
using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealWiseAPI.Repositories.Implementations;

public class IngredientRepository : IIngredientRepository
{
    private readonly MealWiseContext _context;
    public IngredientRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        return await _context.Ingredients.ToListAsync();
    }
    public async Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        return await _context.Ingredients.FindAsync(id);
    }
    public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
    {
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        return ingredient;
    }
    public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();
        return ingredient;
    }
    public async Task DeleteIngredientAsync(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task<Ingredient> GetOrCreateIngredientAsync(string name, string unitType)
    {
        var ingredient = await _context.Ingredients
            .FirstOrDefaultAsync(i => i.Name.ToLower() == name.ToLower());

        if (ingredient == null)
        {
            ingredient = new Ingredient
            {
                Name = name,
                UnitType = unitType
            };

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
        }

        return ingredient;
    }
}
