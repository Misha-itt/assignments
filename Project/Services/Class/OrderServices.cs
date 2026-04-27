using System.Collections.Generic;
using AutoMapper;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repository.Interface;
using Project.Services.Interface;
using Hangfire;

namespace Project.Services.Class
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        private readonly IPaymentService _paymentService;
        private readonly IProductRepository _productRepo;
        private readonly AppDBContext _context;


        public OrderService(IOrderRepository repo, IProductRepository productRepo, IMapper mapper , ILogger<OrderService> logger, 
            IPaymentService paymentService , AppDBContext context )
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
            _paymentService = paymentService;
            _productRepo = productRepo;
            _context = context;
            
        }

     
        public List<OrderResponseDTO> GetOrders(OrderQueryParams query)
        {
            var orders = _repo.GetOrders(query);
            _logger.LogInformation("Fetching the order", query);
            return _mapper.Map<List<OrderResponseDTO>>(orders);   
        }


        public List<OrderSummaryDTO> GetOrderSummary()
        {
            return _repo.GetOrderSummary();
        }

        public async Task< OrderResponseDTO> CreateAsync(OrdersDTO dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = new Orders
                {
                    CustomerName = dto.CustomerName,
                    Email = dto.Email,
                    Address = dto.Address,
                    AddressId = dto.AddressId,
                    PaymentMethod = dto.PaymentMethod,
                    UserId = dto.UserId,
                    Status = "Pending",
                    PaymentStatus = "Pending",
                    OrderDate = DateTime.UtcNow,
                    OrderItems = new List<OrderItem>()
                };

                decimal total = 0;
                foreach (var item in dto.OrderItems)
                {
                    
                    var product = await _productRepo.GetByIdAsync(item.ProductId)
                        ?? throw new KeyNotFoundException($"Product {item.ProductId} not found");

                    if (!product.IsActive)
                        throw new InvalidOperationException($"Product '{product.Pname}' is not available");

                   
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


                var created = _repo.Create(order);
                await transaction.CommitAsync();

               
                var success = await _paymentService.ProcessPaymentAsync(created);

                created.PaymentStatus = success ? "Paid" : "Failed";
                _repo.Update(created.Id, created);

                _logger.LogInformation("Payment {Status} for Order {Id}", created.PaymentStatus, created.Id);

                return _mapper.Map<OrderResponseDTO>(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }



        public async Task ProcessPaymentJob(int orderId)
        {
            var order = await _repo.GetByIdAsync(orderId);
            if (order == null) { _logger.LogWarning("PaymentJob: Order {Id} not found", orderId); return; }

            
            if (order.PaymentStatus != "Pending")
            {
                _logger.LogInformation("Order {Id} already processed, skipping retry", orderId);
                return;
            }

            var success = await _paymentService.ProcessPaymentAsync(order);
            _repo.Update(order.Id, order);

            if (!success)
            {
                _logger.LogWarning("Payment failed for Order {Id}, retrying in 2 minutes", orderId);
                //BackgroundJob.Schedule(() => ProcessPaymentJob(orderId), TimeSpan.FromMinutes(2));
            }
            else _logger.LogInformation("Payment succeeded for Order {Id}", orderId);
        }
    

    public OrderResponseDTO? Update(int id, OrdersDTO dto)
        {
            var order = _mapper.Map<Orders>(dto);
            var updated = _repo.Update(id, order);
            if (updated == null) return null;
            return _mapper.Map<OrderResponseDTO>(updated);
        }

       
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}