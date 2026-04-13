namespace Project.Models
{

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}