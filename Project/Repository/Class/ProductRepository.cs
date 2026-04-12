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
                products = products.Where(p => p.Pname.Contains(query.Name));

            if (query.MinPrice.HasValue)
                products = products.Where(p => p.Price >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                products = products.Where(p => p.Price <= query.MaxPrice.Value);

            if (query.InStock.HasValue && query.InStock.Value)
                products = products.Where(p => p.Stock > 0);

            return products
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToList();
        }
        public Product Create(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return p;
        }

        public List<ProductSalesDTO> GetProductSalesSummary()
        {
            return context.OrderItem
                .Join(context.Products,
                      oi => oi.ProductId,  
                      p => p.Id,            
                      (oi, p) => new { oi, p })
                .GroupBy(x => new { x.p.Id, x.p.Pname })
                .Select(g => new ProductSalesDTO
                {
                    ProductId = g.Key.Id,
                    ProductName = g.Key.Pname,
                    TotalQuantity = g.Sum(x => x.oi.Quantity),
                    TotalRevenue = g.Sum(x => x.oi.Quantity * x.oi.Price)
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