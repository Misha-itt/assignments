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
        public string Uname { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Phone { get; set; } 
        public UserRole Role { get; set; } = UserRole.Customer;
        public List<Orders>? Orders { get; set; }
    }
}