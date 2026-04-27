public class OrderResponseDTO
{
    public int Id { get; set; }
    public string?CustomerName { get; set; }
    public string?Email { get; set; }
    public string? Address { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "";
    public string PaymentStatus { get; set; } = "";
    public string? TransactionId { get; set; }
    public string? PaymentMethod { get; set; }

    public List<OrderItemDTO> Items { get; set; } = new();
}