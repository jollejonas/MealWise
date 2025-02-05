using MealWise.Models;
using MealWise.Services.Interfaces;
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
    public async Task<IEnumerable<ShoppingList>> GetShoppingLists()
    {
        return await _shoppingListService.GetShoppingListsAsync();
    }
    [HttpGet("{id}")]
    public async Task<ShoppingList> GetShoppingListById(int id)
    {
        return await _shoppingListService.GetShoppingListByIdAsync(id);
    }
    [HttpPost("{mealPlanId}/shopping-list")]
    public async Task<IResult> CreateShoppingList(int mealPlanId)
    {
        var shoppingList = await _shoppingListService.CreateShoppingListAsync(mealPlanId);

        if (shoppingList == null)
        {
            return Results.NotFound("Mealplan not found");
        }

        return Results.Ok(shoppingList);
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
