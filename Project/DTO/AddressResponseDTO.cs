public class AddressResponseDTO
{
    public int Id { get; set; }
    public string Line1 { get; set; } = "";
    public string? Line2 { get; set; }
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string Pincode { get; set; } = "";
    public string Country { get; set; } = "";
    public string Label { get; set; } = "";
    public bool IsDefault { get; set; }
}
