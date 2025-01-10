using MealWise.Models;
using MealWise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWise.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _userService.GetUsersAsync();
    }
    [HttpGet("{id}")]
    public async Task<User> GetUserById(int id)
    {
        return await _userService.GetUserByIdAsync(id);
    }
    [HttpPost]
    public async Task<User> CreateUser([FromBody] User user)
    {
        return await _userService.CreateUserAsync(user);
    }
    [HttpPut]
    public async Task<User> UpdateUser([FromBody] User user)
    {
        return await _userService.UpdateUserAsync(user);
    }
    [HttpDelete("{id}")]
    public async Task DeleteUser(int id)
    {
        await _userService.DeleteUserAsync(id);
    }
}
