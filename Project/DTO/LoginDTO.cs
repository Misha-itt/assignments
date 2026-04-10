using System.Collections.Generic;
using Project.Models;
using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}