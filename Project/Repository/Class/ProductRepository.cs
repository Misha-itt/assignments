using Project.Repository.Interface;

namespace Project.Repository.Class
{
    public class ProductRepository : IProductRepository
    {
        private AppDBContext context;

        public ProductRepository(AppDBContext db)
        {
            context = db;
        }

        public List<Product> Get(ProductQueryParams query)
        {
            var products = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                products = products.Where(product => product.Pname.Contains(query.Name));

            if (query.MinPrice.HasValue)
                products = products.Where(product => product.Price >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                products = products.Where(product => product.Price <= query.MaxPrice.Value);

            if (query.InStock.HasValue && query.InStock.Value)
                products = products.Where(product => product.Stock > 0);

            return products
                .Select(product => new Product 
                {
                    Id = product.Id,
                    Pname = product.Pname,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageUrl = product.ImageUrl
                })
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)

                .ToList();
        }
        public Product Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public List<ProductSalesDTO> GetProductSalesSummary()
        {
            return context.OrderItem
                .Join(context.Products,
                      orderitem => orderitem.ProductId,  
                      product => product.Id,            
                      (orderitem, product) => new { orderitem, product })
                .GroupBy(x => new { x.product.Id, x.product.Pname })
                .Select(productsale => new ProductSalesDTO
                {
                    ProductId = productsale.Key.Id,
                    ProductName = productsale.Key.Pname,
                    TotalQuantity = productsale.Sum(x => x.orderitem.Quantity),
                    TotalRevenue = productsale.Sum(x => x.orderitem.Quantity * x.orderitem.Price)
                })
                .ToList();
        }

        public Product? Update(int id, Product product)
        {
            var existing = context.Products.Find(id);
            if (existing == null) return null;

            existing.Pname = product.Pname;
            existing.Price = product.Price;
            existing.Stock = product.Stock;

            context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) return false;

            context.Products.Remove(product);
            context.SaveChanges();
            return true;
        }
    }
}