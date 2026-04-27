public class WishlistItemDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string? Category { get; set; }
    public bool IsInStock { get; set; }   // true if Stock > 0
    public DateTime AddedAt { get; set; }
}