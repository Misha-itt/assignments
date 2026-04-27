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
        public string Password { get; set; } 
        public string Phone { get; set; } 
        public UserRole Role { get; set; } = UserRole.Customer;
        public Cart? Cart { get; set; }
        public Wishlist? Wishlist { get; set; }

        public List<Address>? Addresses { get; set; }   
     
        public List<Orders>? Orders { get; set; }
    }
}