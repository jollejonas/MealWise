using MealWiseAPI.Models;
using MealWiseAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWiseAPI.Controllers;

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

    [HttpPost("upload-image")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is null or empty");
        }
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/images");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqeFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadsFolder, uniqeFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var fileUrl = $"/uploads/images/{uniqeFileName}";

        return Ok(new { imageUrl = fileUrl });
    }
}
