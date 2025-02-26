using System.ComponentModel.DataAnnotations;

namespace MealWiseAPI.Models;

public enum UserRole
{
    User,
    Admin
}
public class User
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

