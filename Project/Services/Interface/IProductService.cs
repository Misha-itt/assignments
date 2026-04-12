using Project.Repository.Class; 

namespace Project.Services.Interface
{
    public interface IProductService
    {
        List<ProductResponseDTO> Get(ProductQueryParams query);
        Product Create(ProductDTO dto);
        Product? Update(int id, ProductDTO dto);
        bool Delete(int id);
        List<ProductSalesDTO> GetProductSalesSummary();
    }
}