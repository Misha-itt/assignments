using Project.Models;
namespace Project.Repository.Interface
{
    public interface IWishlistRepository
    {
        Task<Wishlist?> GetByUserIdAsync(int userId);
        Task<Wishlist> CreateAsync(int userId);
        Task<WishlistItem?> GetItemAsync(int wishlistId, int productId);
        Task AddItemAsync(WishlistItem item);
        Task RemoveItemAsync(WishlistItem item);
        Task ClearAsync(int wishlistId);
    }
}