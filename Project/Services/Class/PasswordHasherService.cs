using Microsoft.AspNetCore.Identity;
using Project.Models;

public class PasswordHasherService
{
    private readonly PasswordHasher<User> _hasher = new();

    public string Hash(User user, string password)
    {
        return _hasher.HashPassword(user, password);
    }

    public bool Verify(User user, string hashedPassword, string password)
    {
        var result = _hasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}