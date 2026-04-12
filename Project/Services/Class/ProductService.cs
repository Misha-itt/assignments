using Project.Repository.Interface;
using Project.Services.Interface;
using AutoMapper;


namespace Project.Services.Class
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<ProductResponseDTO> Get(ProductQueryParams query)
        {
            var products = _repo.Get(query);
            return _mapper.Map<List<ProductResponseDTO>>(products);

        }

        public Product Create(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            return _repo.Create(product);
        }

        public List<ProductSalesDTO> GetProductSalesSummary()
        {
            return _repo.GetProductSalesSummary();
        }
        

        public Product? Update(int id, ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            return _repo.Update(id, product);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}