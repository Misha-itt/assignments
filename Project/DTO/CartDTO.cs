public class CartDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItemDTO> Items { get; set; } = new();
    // computed — not stored in DB
    public decimal TotalAmount => Items.Sum(i => i.Price * i.Quantity);
    public int TotalItems => Items.Sum(i => i.Quantity);
}