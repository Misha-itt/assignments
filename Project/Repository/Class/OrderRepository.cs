using Microsoft.EntityFrameworkCore;
using Project.Repository.Interface;
using Project.Models;

namespace Project.Repository.Class
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;

        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

       
        public List<OrderResponseDTO> GetOrders(OrderQueryParams query)
        {
            var orders = _context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(query.CustomerName))
            {
                orders = orders.Where(o => o.CustomerName.Contains(query.CustomerName));
            }

         
            if (query.FromDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= query.FromDate.Value);
            }

            if (query.ToDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= query.ToDate.Value);
            }

           
            int pageNumber = query.PageNumber <= 0 ? 1 : query.PageNumber;
            int pageSize = query.PageSize <= 0 ? 10 : query.PageSize;

        
            return orders
                .OrderByDescending(o => o.OrderDate) 
                .Select(o => new OrderResponseDTO
                {
                    Id = o.Id,
                    CustomerName = o.CustomerName,
                    Email = o.Email,
                    Address = o.Address,
                    OrderDate = o.OrderDate,

                  
                    TotalAmount = o.TotalPrice

                    
                })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

      
        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Orders? GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public Orders Create(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Orders? Update(int id, Orders order)
        {
            var existing = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (existing == null) return null;

            existing.CustomerName = order.CustomerName;
            existing.Email = order.Email;
            existing.Address = order.Address;
            existing.Quantity = order.Quantity;
            existing.TotalPrice = order.TotalPrice;
            existing.PaymentMethod = order.PaymentMethod;
            existing.OrderDate = order.OrderDate;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null) return false;

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }
    }
}