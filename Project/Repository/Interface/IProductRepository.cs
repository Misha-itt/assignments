using Project.Repository.Class;

namespace Project.Repository.Interface
{
    public interface IProductRepository
    {
        List<ProductResponseDTO> Get(ProductQueryParams query);
        Product Create(Product p);
        Product?Update(int id, Product p);
        bool Delete(int id);
    }
}