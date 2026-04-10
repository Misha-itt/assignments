using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Project.Services.Interface;
using Project.Models;
using Microsoft.AspNetCore.RateLimiting;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
     

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.RegisterAsync(dto.Uname, dto.Email, dto.Password, dto.Phone, dto.Role);
            if (user == null)
                return BadRequest("User already exists");

            return Ok(new { Message = "User registered successfully" });
        }


        [HttpPost("login")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _userService.LoginAsync(dto.Email, dto.Password);
            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }


        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var email = User.Identity?.Name;
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            return Ok(new { Email = email, Role = role });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [Authorize(Roles = "Customer")]
        [HttpGet("my-orders")]
        public IActionResult GetMyOrders()
        {
            var email = User.Identity?.Name;

            return Ok(new { Message = $"Orders for {email}" });
        }
    }
}