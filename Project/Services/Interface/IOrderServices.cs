using Project.Models;
using System.Collections.Generic;


namespace Project.Services.Interface
{
    public interface IOrderService
    {
       //OrderResponseDTO? GetById(int id);

        Task<OrderResponseDTO> CreateAsync(OrdersDTO dto);

        OrderResponseDTO? Update(int id, OrdersDTO order);
        bool Delete(int id);

        List<OrderResponseDTO> GetOrders(OrderQueryParams query);
        List<OrderSummaryDTO> GetOrderSummary();
       
    }
}
