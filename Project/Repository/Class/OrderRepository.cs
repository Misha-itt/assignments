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
        var orders = _context.Orders.Include(o => o.OrderItems).AsQueryable();

        if (!string.IsNullOrEmpty(query.CustomerName))
            orders = orders.Where(o => o.CustomerName.Contains(query.CustomerName));

        if (query.FromDate.HasValue)
            orders = orders.Where(o => o.OrderDate >= query.FromDate.Value);

        if (query.ToDate.HasValue)
            orders = orders.Where(o => o.OrderDate <= query.ToDate.Value);

        int pageNumber = query.PageNumber <= 0 ? 1 : query.PageNumber;
        int pageSize = query.PageSize <= 0 ? 10 : query.PageSize;

        return orders
            .OrderByDescending(o => o.OrderDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Orders Create(Orders order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
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