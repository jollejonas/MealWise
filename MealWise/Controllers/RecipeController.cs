using MealWise.Models;
using MealWise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWise.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    [HttpGet]
    public async Task<IEnumerable<Recipe>> GetRecipes()
    {
        return await _recipeService.GetRecipesAsync();
    }
    [HttpGet("{id}")]
    public async Task<Recipe> GetRecipeById(int id)
    {
        return await _recipeService.GetRecipeByIdAsync(id);
    }
    [HttpPost]
    public async Task<Recipe> CreateRecipe([FromBody] Recipe recipe)
    {
        return await _recipeService.CreateRecipeAsync(recipe);
    }
    [HttpPut]
    public async Task<Recipe> UpdateRecipe([FromBody] Recipe recipe)
    {
        return await _recipeService.UpdateRecipeAsync(recipe);
    }
    [HttpDelete("{id}")]
    public async Task DeleteRecipe(int id)
    {
        await _recipeService.DeleteRecipeAsync(id);
    }
}
