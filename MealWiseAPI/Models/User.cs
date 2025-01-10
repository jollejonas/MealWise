using System.ComponentModel.DataAnnotations;

namespace MealWise.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

