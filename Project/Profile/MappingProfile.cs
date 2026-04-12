using AutoMapper;
using Project.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();

      
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();

        CreateMap<Product, ProductResponseDTO>();
        CreateMap<ProductResponseDTO, Product>();


        CreateMap<Orders, OrdersDTO>();
        CreateMap<OrdersDTO, Orders>();

     
        CreateMap<OrderItem, OrderItemDTO>();
        CreateMap<OrderItemDTO, OrderItem>();
    }
}