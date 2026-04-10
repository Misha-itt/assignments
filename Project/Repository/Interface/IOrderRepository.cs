using Project.Models;

namespace Project.Repository.Interface
{
    public interface IOrderRepository
    {
        //List<Orders> GetOrders();
        Orders Create(Orders order);
        Orders? Update(int id, Orders order);
        bool Delete(int id);

        List<Orders> GetOrders(OrderQueryParams query);
    }
}
