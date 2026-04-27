using Project.Models;

namespace Project.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Orders> GetOrders(OrderQueryParams query);
        Task<Orders?> GetByIdAsync(int id);
        Orders Create(Orders order);
        Orders? Update(int id, Orders order);
        bool Delete(int id);

       

        List<OrderSummaryDTO> GetOrderSummary();
      
    }
}
