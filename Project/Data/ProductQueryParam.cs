public class ProductQueryParams
{
    public string? Name { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? InStock { get; set; }

    public int PageNumber { get; set; } 
    public int PageSize { get; set; }
}