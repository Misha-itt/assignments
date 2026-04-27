using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repository.Interface;

namespace Project.Repository.Class
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly AppDBContext _context;

        public WishlistRepository(AppDBContext context) 
        { 
            _context = context; 
        }

        public async Task<Wishlist?> GetByUserIdAsync(int userId)
            => await _context.Wishlists
                .Include(w => w.Items)
                    .ThenInclude(wi => wi.Product)
                .FirstOrDefaultAsync(w => w.UserId == userId);

        public async Task<Wishlist> CreateAsync(int userId)
        {
            var wishlist = new Wishlist { UserId = userId };
            _context.Wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
            return wishlist;
        }

        public async Task<WishlistItem?> GetItemAsync(int wishlistId, int productId)
            => await _context.WishlistItems
                .FirstOrDefaultAsync(wi => wi.WishlistId == wishlistId && wi.ProductId == productId);

        public async Task AddItemAsync(WishlistItem item)
        {
            _context.WishlistItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(WishlistItem item)
        {
            _context.WishlistItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task ClearAsync(int wishlistId)
        {
            var items = await _context.WishlistItems
                .Where(wi => wi.WishlistId == wishlistId).ToListAsync();
            _context.WishlistItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}