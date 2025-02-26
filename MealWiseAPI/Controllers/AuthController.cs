using MealWiseAPI.DTOs;
using MealWiseAPI.Models;
using MealWiseAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealWiseAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var token = await _authService.AuthenticateUser(loginDto.Username, loginDto.Password);

        if (token == null)
        {
            return Unauthorized(new { message = "Forkert brugernavn eller adgangskode." });
        }

        return Ok(new { token });
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDTO userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingUser = await _userService.GetUserByUsernameAsync(userDto.Username);
        if (existingUser != null)
        {
            return Conflict(new { message = "Brugernavn er allerede taget." });
        }

        var hashedPassword = _authService.HashPassword(userDto.Password);

        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            PasswordHash = hashedPassword,
            Role = userDto.Role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(Register), new { userId = createdUser.Id }, new { message = "Bruger oprettet!" });
    }
}