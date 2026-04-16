using System.Collections.Generic;
using AutoMapper;
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
        private readonly AppDBContext _context;

        public OrderService(IOrderRepository repo, IMapper mapper , ILogger<OrderService> logger, 
            IPaymentService paymentService, AppDBContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
            _paymentService = paymentService;
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
                var order = _mapper.Map<Orders>(dto);
                order.Status = "Pending";
                order.PaymentStatus = "Pending";
                order.OrderDate = DateTime.UtcNow;

                order.TotalPrice = order.OrderItems?.Sum(i => i.Price * i.Quantity) ?? 0;

              

                var createdOrder = _repo.Create(order);

                await transaction.CommitAsync();
                _repo.Update(createdOrder.Id, createdOrder);

                BackgroundJob.Enqueue(() => ProcessPaymentJob(createdOrder.Id));
                return _mapper.Map<OrderResponseDTO>(createdOrder);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating order with payment");
                throw;
            }
        }

     

public async Task ProcessPaymentJob(int orderId)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);

        if (order == null) return;

        var success = await _paymentService.ProcessPaymentAsync(order);

        _repo.Update(order.Id, order);

        if (!success)
        {
            _logger.LogWarning("Payment failed, retrying OrderId: {Id}", order.Id);

        
            BackgroundJob.Schedule(
                () => ProcessPaymentJob(orderId),
                TimeSpan.FromMinutes(2)
            );
        }
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