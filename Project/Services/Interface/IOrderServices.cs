using Project.Models;
using System.Collections.Generic;


namespace Project.Services.Interface
{
    public interface IOrderService
    {
       // List<OrderResponseDTO> GetOrders();
       // OrderResponseDTO? GetById(int id);
        OrderResponseDTO Create(OrdersDTO order);
        OrderResponseDTO? Update(int id, OrdersDTO order);
        bool Delete(int id);

        List<OrderResponseDTO> GetOrders(OrderQueryParams query);
    }
}
