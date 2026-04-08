
using System.Collections.Generic; 
using Project.Models;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> AddUserAsync(User user);

    Task<List<User>> GetAllUsersAsync();
}