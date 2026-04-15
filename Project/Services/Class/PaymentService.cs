using Project.Models;
using Project.Services.Interface;

namespace Project.Services.Class
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> ProcessPaymentAsync(Orders order)
        {
            await Task.Delay(1000);
            bool isSuccess = new Random().Next(0, 2) == 1;
            order.TransactionId = Guid.NewGuid().ToString();
            if (isSuccess)
            {
                order.PaymentStatus = "Success";
                order.Status = "Confirmed";
            }
            else
            {
                order.PaymentStatus = "Failed";
                order.Status = "Cancelled";
            }
            return isSuccess;
        }
    }
}
