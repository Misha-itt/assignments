public class Product
{
    public int Id{get;set;}
    public string? Pname{get;set;}
    public decimal Price{get;set;}
    public int Stock {get;set;}

    public List<OrderItem>?OrderItems {get;set;}
}