using Project.Repository.Class; 

namespace Project.Services.Interface
{
    public interface IProductService
    {
        List<ProductResponseDTO> Get(ProductQueryParams query);
        Product Create(Product p);
        Product? Update(int id, Product p);
        bool Delete(int id);
    }
}