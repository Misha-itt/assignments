using Project.Models;
using System.Collections.Generic;

namespace Project.Services.Interface
{

    public interface IUserService
    {
        //Task<User?> RegisterAsync(string uname, string email, string password, string phone, UserRole role = UserRole.Customer);
        Task<string?> LoginAsync(string email, string password);
        Task<UserDTO?> RegisterAsync(RegisterDTO dto);
        Task<List<UserDTO>> GetAllUsersAsync();
    }
}