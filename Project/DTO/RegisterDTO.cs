
using Project.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class RegisterDTO
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Uname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid 10-digit phone number")]

    public string Phone { get; set; }

    public UserRole Role { get; set; } = UserRole.Customer;
}

