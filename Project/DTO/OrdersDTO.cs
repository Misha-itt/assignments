public class OrdersDTO
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
    public string? Order_date { get; set; }
    public int? AddressId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal TotalPrice { get; set; }
    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }


    public List<OrderItemDTO> OrderItems { get; set; } 
}