using Project.Models;

namespace Project.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Orders> GetAll();
        Orders? GetById(int id);
        Orders Create(Orders order);
        Orders? Update(int id, Orders order);
        bool Delete(int id);

        List<OrderResponseDTO> GetOrders(OrderQueryParams query);
    }
}
