using Project.Models;
using Project.Repository.Interface;
using Project.Services.Interface;
using Hangfire;

namespace Project.Services.Class
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly ILogger<CartService> _logger;
        private readonly AppDBContext _context;

        public CartService(ICartRepository cartRepo, IProductRepository productRepo,
            IOrderRepository orderRepo, IAddressRepository addressRepo, ILogger<CartService> logger , AppDBContext context)
        {
            _cartRepo = cartRepo; 
            _productRepo = productRepo;
            _orderRepo = orderRepo; 
            _addressRepo = addressRepo; 
            _logger = logger;
            _context = context;
        }

        public async Task<CartDTO?> GetCartAsync(int userId)
        {
            var cart = await _cartRepo.GetByUserIdAsync(userId);
            return cart == null ? null : MapToDTO(cart);
        }

        public async Task<CartDTO> AddToCartAsync(int userId, AddToCartDTO dto)
        {
            var product = await _productRepo.GetByIdAsync(dto.ProductId)
                ?? throw new KeyNotFoundException("Product not found");

            if (!product.IsActive)
                throw new InvalidOperationException("Product is not available");
            if (product.Stock < dto.Quantity)
                throw new InvalidOperationException($"Only {product.Stock} left in stock");

           
            var cart = await _cartRepo.GetByUserIdAsync(userId)
                    ?? await _cartRepo.CreateCartAsync(userId);

          
            var existing = await _cartRepo.GetCartItemAsync(cart.Id, dto.ProductId);
            if (existing != null)
            {
                int newQty = existing.Quantity + dto.Quantity;
                if (newQty > product.Stock)
                    throw new InvalidOperationException($"Only {product.Stock} available in total");
                existing.Quantity = newQty;
                await _cartRepo.UpdateItemAsync(existing);
            }
            else
            {
                await _cartRepo.AddItemAsync(new CartItem
                {
                    CartId = cart.Id,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                });
            }

            var updated = await _cartRepo.GetByUserIdAsync(userId);
            _logger.LogInformation("Product {P} added to cart, user {U}", dto.ProductId, userId);
            return MapToDTO(updated!);
        }

        public async Task<CartDTO?> UpdateQuantityAsync(int userId, int productId, int quantity)
        {
            var cart = await _cartRepo.GetByUserIdAsync(userId);
            if (cart == null) return null;

            var item = await _cartRepo.GetCartItemAsync(cart.Id, productId);
            if (item == null) return MapToDTO(cart);

            if (quantity <= 0)
                await _cartRepo.RemoveItemAsync(item);
            else
            {
                var product = await _productRepo.GetByIdAsync(productId);
                if (product != null && quantity > product.Stock)
                    throw new InvalidOperationException($"Only {product.Stock} available");
                item.Quantity = quantity;
                await _cartRepo.UpdateItemAsync(item);
            }
            var updated = await _cartRepo.GetByUserIdAsync(userId);
            return updated != null ? MapToDTO(updated) : null;
        }

        public async Task<bool> RemoveFromCartAsync(int userId, int productId)
        {
            var cart = await _cartRepo.GetByUserIdAsync(userId);
            if (cart == null) return false;
            var item = await _cartRepo.GetCartItemAsync(cart.Id, productId);
            if (item == null) return false;
            await _cartRepo.RemoveItemAsync(item);
            return true;
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            var cart = await _cartRepo.GetByUserIdAsync(userId);
            if (cart == null) return false;
            await _cartRepo.ClearCartAsync(cart.Id);
            return true;
        }

      
        public async Task<OrderResponseDTO> CheckoutAsync(int userId, CheckoutDTO dto)
        {
            var cart = await _cartRepo.GetByUserIdAsync(userId);
            if (cart == null || !cart.Items.Any())
                throw new InvalidOperationException("Your cart is empty.");

          
            string addressText = dto.Address ?? "";
            if (dto.AddressId.HasValue)
            {
                var saved = await _addressRepo.GetByIdAsync(dto.AddressId.Value);
                if (saved != null)
                    addressText = $"{saved.Line1}, {(saved.Line2 != null ? saved.Line2 + ", " : "")}{saved.City}, {saved.State} - {saved.Pincode}";
            }
            if (string.IsNullOrEmpty(addressText))
                throw new InvalidOperationException("Please provide a delivery address.");

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = new Orders
                {
                    UserId = userId,
                    Address = addressText,
                    AddressId = dto.AddressId,
                    PaymentMethod = dto.PaymentMethod,
                    Status = "Pending",
                    PaymentStatus = "Pending",
                    OrderDate = DateTime.UtcNow,
                    OrderItems = new List<OrderItem>()
                };

                decimal total = 0;
                foreach (var item in cart.Items)
                {
                    var product = await _productRepo.GetByIdAsync(item.ProductId)
                        ?? throw new KeyNotFoundException($"Product {item.ProductId} not found");

                    if (product.Stock < item.Quantity)
                        throw new InvalidOperationException(
                            $"Not enough stock for '{product.Pname}'. Available: {product.Stock}");

                    order.OrderItems.Add(new OrderItem
                    {
                        ProductId = item.ProductId,
                        ProductName = product.Pname,
                        Quantity = item.Quantity,
                        Price = product.Price
                    });
                    total += product.Price * item.Quantity;
                    product.Stock -= item.Quantity;
                }
                order.TotalPrice = total;

                var created = _orderRepo.Create(order);
                await _cartRepo.ClearCartAsync(cart.Id);  
                await transaction.CommitAsync();

                //BackgroundJob.Enqueue<OrderService>(s => s.ProcessPaymentJob(created.Id));
                _logger.LogInformation("Checkout: Order {Id} created for user {U}", created.Id, userId);

                return new OrderResponseDTO
                {
                    Id = created.Id,
                    TotalPrice = created.TotalPrice,
                    Status = created.Status,
                    PaymentStatus = created.PaymentStatus,
                    OrderDate = created.OrderDate,
                    Address = created.Address,
                    Items = created.OrderItems?.Select(oi => new OrderItemDTO
                    {
                        Id = oi.Id,
                        ProductId = oi.ProductId,
                        ProductName = oi.ProductName,
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList() ?? new()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Checkout failed for user {U}", userId);
                throw;
            }
        }

        private CartDTO MapToDTO(Cart cart) => new CartDTO
        {
            Id = cart.Id,
            UserId = cart.UserId,
            Items = cart.Items?.Select(ci => new CartItemDTO
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Pname ?? "",
                Price = ci.Product?.Price ?? 0,
                Quantity = ci.Quantity,
                ImageUrl = ci.Product?.ImageUrl
            }).ToList() ?? new()
        };
    }
}