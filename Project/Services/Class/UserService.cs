using Project.Models;
using Project.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Project.Services.Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, JwtService jwtService,IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<User>();
            _mapper = mapper;
        }

        public async Task<User?> RegisterAsync(string uname, string email, string password, string phone, UserRole role = UserRole.Customer)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null) return null;

            var user = new User
            {
                Uname = uname,
                Email = email,
                Phone = phone,
                Role = role
            };

            user.Password = _passwordHasher.HashPassword(user, password);
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result != PasswordVerificationResult.Success)
                return null;

            return _jwtService.GenerateToken(user.Email, user.Role);
        }

       
        public async Task<List<User>> GetAllUsersAsync()
        {
     
            return await _userRepository.GetAllUsersAsync();
        }
    }
}