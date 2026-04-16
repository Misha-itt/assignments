using Project.Models;
using System.Collections.Generic;


namespace Project.Services.Interface
{
    public interface IOrderService
    {

        Task<OrderResponseDTO> CreateAsync(OrdersDTO dto);

        OrderResponseDTO? Update(int id, OrdersDTO order);
        bool Delete(int id);

        List<OrderResponseDTO> GetOrders(OrderQueryParams query);
        List<OrderSummaryDTO> GetOrderSummary();

        Task ProcessPaymentJob(int orderId);
    }
}
