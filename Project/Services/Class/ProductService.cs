using Project.Repository.Interface;
using Project.Services.Interface;
using AutoMapper;


namespace Project.Services.Class
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repo , IMapper mapper , ILogger<ProductService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        public List<ProductResponseDTO> Get(ProductQueryParams query)
        {
            var products = _repo.Get(query);
            _logger.LogInformation("Fetching the product : {@query}", query);
            return _mapper.Map<List<ProductResponseDTO>>(products);

        }

        public async Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductResponseDTO>(product);
        }

        public ProductResponseDTO Create(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var created = _repo.Create(product);
            return _mapper.Map<ProductResponseDTO>(created);
        }

        public List<ProductSalesDTO> GetProductSalesSummary()
        {
            return _repo.GetProductSalesSummary();
        }
        

        public ProductResponseDTO? Update(int id, ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var updated = _repo.Update(id, product);
            if (updated == null) return null;

            return _mapper.Map<ProductResponseDTO>(updated);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}