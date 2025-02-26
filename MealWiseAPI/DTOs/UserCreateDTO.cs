using MealWiseAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MealWiseAPI.DTOs;

public class UserCreateDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "Ugyldig e-mail adresse.")]
    public string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password skal være mindst 8 tegn.")]
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
