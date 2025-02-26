using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using MealWiseAPI.Services.Interfaces;


namespace MealWiseAPI.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _userRepository.GetUsersAsync();
    }
    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        user.PasswordHash = null;

        return user;
    }
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _userRepository.GetUserByUsernameAsync(username);
    }
    public async Task<User> CreateUserAsync(User user)
    {
        return await _userRepository.CreateUserAsync(user);
    }
    public async Task<User> UpdateUserAsync(User user)
    {
        return await _userRepository.UpdateUserAsync(user);
    }
    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}
