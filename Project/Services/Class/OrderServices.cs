using Project.Repository.Interface;
using Project.Services.Interface;
using Project.Models;
using System.Collections.Generic;

namespace Project.Services.Class
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<OrderResponseDTO> GetOrders(OrderQueryParams query)
        {
            return _repo.GetOrders(query);
        }
        public List<Orders> GetAll()
        {
            return _repo.GetAll();
        }

        public Orders?GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Orders Create(Orders order)
        {
            return _repo.Create(order);
        }

        public Orders? Update(int id, Orders order)
        {
            return _repo.Update(id, order);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
