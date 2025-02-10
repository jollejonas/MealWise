using MealWiseAPI.Data;
using MealWiseAPI.Models;
using MealWiseAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealWiseAPI.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly MealWiseContext _context;
    public UserRepository(MealWiseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
