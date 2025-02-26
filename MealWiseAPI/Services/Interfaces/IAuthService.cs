namespace MealWiseAPI.Services.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateUser(string username, string password);
    string HashPassword(string password);
}
