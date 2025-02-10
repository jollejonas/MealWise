using MealWiseAPI.Models;
using MealWiseAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWiseAPI.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;
    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    [HttpGet]
    public async Task<IEnumerable<Ingredient>> GetIngredients()
    {
        return await _ingredientService.GetIngredientsAsync();
    }
    [HttpGet("{id}")]
    public async Task<Ingredient> GetIngredientById(int id)
    {
        return await _ingredientService.GetIngredientByIdAsync(id);
    }
    [HttpPost]
    public async Task<Ingredient> CreateIngredient([FromBody] Ingredient ingredient)
    {
        return await _ingredientService.CreateIngredientAsync(ingredient);
    }
    [HttpPut]
    public async Task<Ingredient> UpdateIngredient([FromBody] Ingredient ingredient)
    {
        return await _ingredientService.UpdateIngredientAsync(ingredient);
    }
    [HttpDelete("{id}")]
    public async Task DeleteIngredient(int id)
    {
        await _ingredientService.DeleteIngredientAsync(id);
    }
}
