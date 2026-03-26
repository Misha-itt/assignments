using System.Diagnostics.Contracts;

public class Orders
{
    public int Id{get;set;}
    public string? Order_date{get;set;}
    public int User_id{get;set;}

    public User? User{get;set;}

    public List<OrderItem>? OrderItems{get;set;}
}