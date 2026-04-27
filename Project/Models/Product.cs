using Project.Models;

public class Product
{
    public int Id { get; set; }
    public string? Pname { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
    public List<OrderItem>? OrderItems { get; set; }
    public List<CartItem>? CartItems { get; set; }

    public List<WishlistItem>? WishlistItems { get; set; }
}