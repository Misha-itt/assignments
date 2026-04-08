
using Project.Models;
using System.Collections.Generic;

public class RegisterDto
{
    public string Uname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public UserRole Role { get; set; } = UserRole.Customer;
}