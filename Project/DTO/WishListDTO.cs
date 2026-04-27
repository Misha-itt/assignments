public class WishlistDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<WishlistItemDTO> Items { get; set; } = new();
    public int TotalItems => Items.Count;
}