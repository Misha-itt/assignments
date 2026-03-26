public class OrderItem
{
    public int Id {get;set;}
    public int Quantity {get;set;}
    public decimal Price{get;set;}
     public int Prod_id{get;set;}
    public int Order_id{get;set;}

    public Orders? Orders{get;set;}
    public Product? Product{get;set;}
}