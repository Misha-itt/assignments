using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repository.Interface;

public class OrderRepository : IOrderRepository
{
    private readonly AppDBContext _context;

    public OrderRepository(AppDBContext context)
    {
        _context = context;
    }

    public List<Orders> GetOrders(OrderQueryParams query)
    {
        var orders = _context.Orders
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(query.CustomerName))
            orders = orders.Where(orders => orders.CustomerName.Contains(query.CustomerName));

        if (query.FromDate.HasValue)
            orders = orders.Where(orders => orders.OrderDate >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            orders = orders.Where(orders => orders.OrderDate <= query.ToDate.Value);

        int pageNumber = query.PageNumber <= 0 ? 1 : query.PageNumber;
        int pageSize = query.PageSize <= 0 ? 10 : query.PageSize;

        return orders
            .OrderByDescending(o => o.OrderDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            
            .Select(order => new Orders
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Email = order.Email,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,

               OrderItems = order.OrderItems.Select(i => new OrderItem
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                  
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            })
            .ToList();
    }

    public Orders Create(Orders order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }

    public List<OrderSummaryDTO> GetOrderSummary()
    {
        return _context.Orders
            .AsNoTracking()
            .GroupBy(order => order.UserId)
            .Select(ordersummary => new OrderSummaryDTO
            {
                CustomerId = ordersummary.Key,
                TotalOrders = ordersummary.Count(),
                TotalAmount = ordersummary.Sum(x => x.TotalPrice)
            })
            .ToList();
    }

    public Orders? Update(int id, Orders order)
    {
        var existing = _context.Orders.Find(id);
        if (existing == null) return null;

        existing.CustomerName = order.CustomerName;
        existing.Email = order.Email;
        existing.Address = order.Address;
        existing.OrderDate = order.OrderDate;
        existing.TotalPrice = order.TotalPrice;
        existing.PaymentMethod = order.PaymentMethod;

        _context.SaveChanges();
        return existing;
    }

    public bool Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        _context.SaveChanges();
        return true;
    }
}