using Project.Models;

namespace Project.Services.Interface
{
    public interface IPaymentService
    {
        Task<bool> ProcessPaymentAsync(Orders order);
    }
}
