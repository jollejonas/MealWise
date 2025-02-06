using MealWise.Models;
using MealWise.Services.Interfaces;
using MealWiseAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MealWise.Controllers;

[ApiController]
[Route("api/shoppinglists")]
public class ShoppingListController : ControllerBase
{
    private readonly IShoppingListService _shoppingListService;
    public ShoppingListController(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShoppingListDTO>>> GetShoppingLists()
    {
        var shoppingLists = await _shoppingListService.GetShoppingListsAsync();
        return Ok(shoppingLists);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingListDTO>> GetShoppingListById(int id)
    {
        var shoppingList = await _shoppingListService.GetShoppingListByIdAsync(id);
        if (shoppingList == null)
        {
            return NotFound();
        }
        return Ok(shoppingList);
    }
    [HttpPost("create/{mealPlanId}")]
    public async Task<ActionResult<ShoppingListDTO>> CreateShoppingList(int mealPlanId)
    {
        var shoppingList = await _shoppingListService.CreateShoppingListAsync(mealPlanId);
        if (shoppingList == null)
        {
            return NotFound($"Meal plan {mealPlanId} not found.");
        }
        return CreatedAtAction(nameof(GetShoppingListById), new { id = shoppingList.Id }, shoppingList);
    }
    [HttpPut]
    public async Task<ShoppingList> UpdateShoppingList([FromBody] ShoppingList shoppingList)
    {
        return await _shoppingListService.UpdateShoppingListAsync(shoppingList);
    }
    [HttpDelete("{id}")]
    public async Task DeleteShoppingList(int id)
    {
        await _shoppingListService.DeleteShoppingListAsync(id);
    }
}
