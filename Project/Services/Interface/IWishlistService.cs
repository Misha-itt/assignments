namespace Project.Services.Interface
{
    public interface IWishlistService
    {
        Task<WishlistDTO?> GetWishlistAsync(int userId);
        Task<WishlistDTO> AddAsync(int userId, int productId);
        Task<bool> RemoveAsync(int userId, int productId);
        Task<bool> ClearAsync(int userId);
        Task<bool> IsInWishlistAsync(int userId, int productId);
    }
}