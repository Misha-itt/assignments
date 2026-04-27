namespace Project.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Line1 { get; set; } = string.Empty;   
        public string? Line2 { get; set; }                    
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string Country { get; set; } = "";

        public string Label { get; set; } = "Home";   
        public bool IsDefault { get; set; } = false;   

        public int UserId { get; set; }
        public User? User { get; set; }

      
        public List<Orders>? Orders { get; set; }
    }
}