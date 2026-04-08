using Project.Models;
using System.Collections.Generic;


namespace Project.Services.Interface
{
    public interface IOrderService
    {
        List<Orders> GetAll();
        Orders? GetById(int id);
        Orders Create(Orders order);
        Orders? Update(int id, Orders order);
        bool Delete(int id);

        List<OrderResponseDTO> GetOrders(OrderQueryParams query);
    }
}
