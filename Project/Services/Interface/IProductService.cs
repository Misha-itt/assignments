using Project.Repository.Class; 

namespace Project.Services.Interface
{
    public interface IProductService
    {
        List<ProductResponseDTO> Get(ProductQueryParams query);
        Task<ProductResponseDTO?> GetByIdAsync(int id);
        ProductResponseDTO Create(ProductDTO dto);
        ProductResponseDTO? Update(int id, ProductDTO dto);
        bool Delete(int id);
        List<ProductSalesDTO> GetProductSalesSummary();
    }
}