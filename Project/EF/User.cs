public class User
{
    public int Id{get;set;}
    public string? Uname{get;set;}
    public string? Email{get;set;}
    public string?  Password{get;set;}
    public int Phone{get;set;}

    public List<Orders>? Orders {get; set;} 
}