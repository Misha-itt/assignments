namespace Project.Services.Interface
{
    public interface ICartService
    {
        Task<CartDTO?> GetCartAsync(int userId);
        Task<CartDTO> AddToCartAsync(int userId, AddToCartDTO dto);
        Task<CartDTO?> UpdateQuantityAsync(int userId, int productId, int quantity);
        Task<bool> RemoveFromCartAsync(int userId, int productId);
        Task<bool> ClearCartAsync(int userId);
        Task<OrderResponseDTO> CheckoutAsync(int userId, CheckoutDTO dto);
    }
}