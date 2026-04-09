using Project.Repository.Interface;
using Project.Services.Interface;

namespace Project.Services.Class
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<ProductResponseDTO> Get(ProductQueryParams query)
        {
            var products = _repo.Get(query);

            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public Product Create(Product p)
        {
            return _repo.Create(p);
        }

        public Product? Update(int id, Product p)
        {
            return _repo.Update(id, p);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}