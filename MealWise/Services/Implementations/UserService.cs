using MealWise.Models;
using MealWise.Repositories.Interfaces;
using MealWise.Services.Interfaces;


namespace MealWise.Services.Implementations;

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
        return await _userRepository.GetUserByIdAsync(id);
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
