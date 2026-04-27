using Project.Models;
using Project.Repository.Interface;
using Project.Services.Interface;

namespace Project.Services.Class
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _repo;
        private readonly IProductRepository _productRepo;

        public WishlistService(IWishlistRepository repo, IProductRepository productRepo)
        { _repo = repo; _productRepo = productRepo; }

        public async Task<WishlistDTO?> GetWishlistAsync(int userId)
        {
            var wishlist = await _repo.GetByUserIdAsync(userId);
            return wishlist == null ? null : MapToDTO(wishlist);
        }

        public async Task<WishlistDTO> AddAsync(int userId, int productId)
        {
            _ = await _productRepo.GetByIdAsync(productId)
                ?? throw new KeyNotFoundException("Product not found");

            var wishlist = await _repo.GetByUserIdAsync(userId)
                        ?? await _repo.CreateAsync(userId);

           
            var existing = await _repo.GetItemAsync(wishlist.Id, productId);
            if (existing == null)
                await _repo.AddItemAsync(new WishlistItem { WishlistId = wishlist.Id, ProductId = productId });

            var updated = await _repo.GetByUserIdAsync(userId);
            return MapToDTO(updated!);
        }

        public async Task<bool> RemoveAsync(int userId, int productId)
        {
            var wishlist = await _repo.GetByUserIdAsync(userId);
            if (wishlist == null) return false;
            var item = await _repo.GetItemAsync(wishlist.Id, productId);
            if (item == null) return false;
            await _repo.RemoveItemAsync(item);
            return true;
        }

        public async Task<bool> ClearAsync(int userId)
        {
            var wishlist = await _repo.GetByUserIdAsync(userId);
            if (wishlist == null) return false;
            await _repo.ClearAsync(wishlist.Id);
            return true;
        }

        public async Task<bool> IsInWishlistAsync(int userId, int productId)
        {
            var wishlist = await _repo.GetByUserIdAsync(userId);
            if (wishlist == null) return false;
            return await _repo.GetItemAsync(wishlist.Id, productId) != null;
        }

        private WishlistDTO MapToDTO(Wishlist w) => new WishlistDTO
        {
            Id = w.Id,
            UserId = w.UserId,
            Items = w.Items?.Select(wi => new WishlistItemDTO
            {
                Id = wi.Id,
                ProductId = wi.ProductId,
                ProductName = wi.Product?.Pname ?? "",
                Price = wi.Product?.Price ?? 0,
                ImageUrl = wi.Product?.ImageUrl,
                Category = wi.Product?.Category,
                IsInStock = (wi.Product?.Stock ?? 0) > 0,
              
            }).ToList() ?? new()
        };
    }
}