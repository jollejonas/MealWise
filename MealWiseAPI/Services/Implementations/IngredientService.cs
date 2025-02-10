using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using MealWiseAPI.Services.Interfaces;


namespace MealWiseAPI.Services.Implementations;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        return await _ingredientRepository.GetIngredientsAsync();
    }
    public async Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        return await _ingredientRepository.GetIngredientByIdAsync(id);
    }
    public async Task<Ingredient> CreateIngredientAsync(Ingredient ingredient)
    {
        return await _ingredientRepository.CreateIngredientAsync(ingredient);
    }
    public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
    {
        return await _ingredientRepository.UpdateIngredientAsync(ingredient);
    }
    public async Task DeleteIngredientAsync(int id)
    {
        await _ingredientRepository.DeleteIngredientAsync(id);
    }
    public async Task<Ingredient> GetOrCreateIngredientAsync(string name, string unitType)
    {
        return await _ingredientRepository.GetOrCreateIngredientAsync(name, unitType);
    }
}
