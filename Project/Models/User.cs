namespace Project.Models
{

    public enum UserRole
    {
        Customer,
        Admin
    }

    public class User
    {
        public int Id { get; set; }
        public string Uname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Customer;
        public List<Orders>? Orders { get; set; }
    }
}