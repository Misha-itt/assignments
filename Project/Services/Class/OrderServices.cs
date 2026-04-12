using Project.Repository.Interface;
using Project.Services.Interface;
using Project.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Project.Services.Class
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

     
        public List<OrderResponseDTO> GetOrders(OrderQueryParams query)
        {
            var orders = _repo.GetOrders(query);                   
            return _mapper.Map<List<OrderResponseDTO>>(orders);   
        }


        public List<OrderSummaryDTO> GetOrderSummary()
        {
            return _repo.GetOrderSummary();
        }

        public OrderResponseDTO Create(OrdersDTO dto)
        {
            var order = _mapper.Map<Orders>(dto);      
            var created = _repo.Create(order);
            return _mapper.Map<OrderResponseDTO>(created);  
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