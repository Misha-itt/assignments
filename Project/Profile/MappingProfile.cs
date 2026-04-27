using AutoMapper;
using Project.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<User, UserDTO>();
            
       

      
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();

        CreateMap<Product, ProductResponseDTO>();
        CreateMap<ProductResponseDTO, Product>();

        CreateMap<Orders, OrderResponseDTO>()
            .ForMember(d => d.TotalPrice, opt => opt.MapFrom(s => s.TotalPrice))
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
            .ForMember(d => d.PaymentStatus, opt => opt.MapFrom(s => s.PaymentStatus))
            .ForMember(d => d.Items, opt => opt.MapFrom(s => s.OrderItems));



        CreateMap<OrderItem, OrderItemDTO>()
             .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.ProductName));

        CreateMap<Address, AddressResponseDTO>();
        CreateMap<AddressDTO, Address>();
    }
}