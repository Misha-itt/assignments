using AutoMapper;

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


        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, Order>();

     
        CreateMap<OrderItem, OrderItemDTO>();
        CreateMap<OrderItemDTO, OrderItem>();
    }
}