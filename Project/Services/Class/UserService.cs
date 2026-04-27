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
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, JwtService jwtService,IMapper mapper, ILogger<UserService> logger)
        { 
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<User>();
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO?> RegisterAsync(RegisterDTO dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration attempt with existing email: {Email}", dto.Email);
                return null;
            }

            var user = new User
            {
                Uname = dto.Uname,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role
            };
         

            user.Password = _passwordHasher.HashPassword(user,dto.Password);
            var created = await _userRepository.AddUserAsync(user);
            _logger.LogInformation("User registered: {Email}", created.Email);
            return _mapper.Map<UserDTO>(created);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result != PasswordVerificationResult.Success)
                return null;

            return _jwtService.GenerateToken(user.Email, user.Role, user.Id);
        }

       
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {

            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDTO>>(users);
            
        }
    }
}