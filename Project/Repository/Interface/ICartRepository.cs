using Project.Models;
namespace Project.Repository.Interface
{
    public interface ICartRepository
    {
        Task<Cart?> GetByUserIdAsync(int userId);
        Task<Cart> CreateCartAsync(int userId);
        Task<CartItem?> GetCartItemAsync(int cartId, int productId);
        Task AddItemAsync(CartItem item);
        Task UpdateItemAsync(CartItem item);
        Task RemoveItemAsync(CartItem item);
        Task ClearCartAsync(int cartId);
        Task SaveChangesAsync();
    }
}