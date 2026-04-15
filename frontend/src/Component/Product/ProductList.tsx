import { useState, useMemo } from "react";
import ProductCard, { Product } from "./ProductCard";
import { useGetProductsQuery } from "./ProductService";
import { useNavigate } from "react-router-dom";
import { NAVBAR, SIDEBAR, CONTENT, PAGINATION, PAGE } from "./ProductConstant";
import "./ProductList.css";



function SkeletonCard() {
  return (
    <div className="skeleton-card">
      <div className="skeleton-img" />
      <div className="skeleton-line" />
      <div className="skeleton-line short" />
    </div>
  );
}


function ProductList() {
  const navigate = useNavigate();
  const [page, setPage] = useState(1);
  const [sort, setSort] = useState("default");
  const [wishlist, setWishlist] = useState<number[]>([]);
  const [quickView, setQuickView] = useState<Product | null>(null);

  const [filters, setFilters] = useState({
    search: "",
    minPrice: "",
    maxPrice: "",
    inStockOnly: false,
  });

  const pageSize = PAGE.Pagesize;

 
  const buildQuery = () => {
    return new URLSearchParams({
      pageNumber: page.toString(),
      pageSize: pageSize.toString(),
      ...(filters.search && { name: filters.search }),
      ...(filters.minPrice && { minPrice: filters.minPrice }),
      ...(filters.maxPrice && { maxPrice: filters.maxPrice }),
      ...(filters.inStockOnly && { inStock: "true" }),
    }).toString();
  };

  const query = buildQuery();


  const { data: products = [], error, isLoading } = useGetProductsQuery(query);

  const sortedProducts = useMemo(() => {
    let data = [...products];

    if (sort === "low") data.sort((a, b) => a.price - b.price);
    if (sort === "high") data.sort((a, b) => b.price - a.price);

    return data;
  }, [products, sort]);

  const toggleWishlist = (id:number) => {
    setWishlist((prev) =>
      prev.includes(id) ? prev.filter((x) => x !== id) : [...prev, id]
    );
  };

  const handleFilterChange = (key: string, value: any) =>
    setFilters((prev) => ({ ...prev, [key]: value }));

  const handleApplyFilters = () => setPage(1);

  const handleAction = (action: string) => {
    if (action === "search") handleApplyFilters();
    if (action === "cart") navigate("/cart");
  };

  const applyFilters = () => setPage(1);
  const hasNext = products.length === pageSize;

  return (
    <div className="plp-page">

    
      <header className="plp-header">
        <div className="brand" onClick={() => navigate("/")}>🛍 {NAVBAR.title}</div>

        
        <input
          className="search"
          placeholder={NAVBAR.searchPlaceholder}
          value={filters.search}
          onChange={(e) => handleFilterChange("search", e.target.value)}
          onKeyDown={(e) => e.key === "Enter" && applyFilters()}
        />

        <select className="sort" value={sort} onChange={(e) => setSort(e.target.value)}>
          <option value="default">Sort</option>
          <option value="low">Price: Low to High</option>
          <option value="high">Price: High to Low</option>
        </select>

        <button onClick={() => navigate("/cart")}>Cart</button>
        <button onClick={() => navigate("/login")}>Login</button>
      </header>

    
      <div className="plp-body">

     
        <aside className="plp-sidebar">
          <h3>{SIDEBAR.title}</h3>

          <div className="filter-box">
            <p><strong>Price</strong></p>
            {SIDEBAR.priceFields.map((f) => (
              <input
                key={f.key}
                type="number"
                placeholder={f.placeholder}
                value={filters[f.key]}
                onChange={(e) => handleFilterChange(f.key, e.target.value)}
              />
            ))}
          </div>

          <div className="filter-box">
            <label>
              <input
                type="checkbox"
                checked={filters.inStockOnly}
                onChange={(e) => handleFilterChange(SIDEBAR.availabilityField.key, e.target.checked)}
              />
              {SIDEBAR.availabilityField.label}
            </label>
             </div>

          <button onClick={applyFilters}>{SIDEBAR.applyButton}</button>
        </aside>

       
        <main className="plp-main">

          {isLoading && (
            <div className="grid">
              {Array.from({ length: 6 }).map((_, i) => (
                <SkeletonCard key={i} />
              ))}
            </div>
          )}

          {error && <div className="error">Failed to load products</div>}

          {!isLoading && sortedProducts.length === 0 && (
            <div className="empty">No products found</div>
             )}

          {!isLoading && sortedProducts.length > 0 && (
            <>
              <div className="grid">
                {sortedProducts.map((p) => (
                  <div className="product-wrapper" key={p.id}>

                    
                    <div className="wishlist" onClick={() => toggleWishlist(p.id)}>
                      {wishlist.includes(p.id) ? "❤️" : "🤍"}
                    </div>

                  
                    <div onClick={() => setQuickView(p)}>
                      <ProductCard product={p} />
                    </div>

                    </div>
                ))}
              </div>

              <div className="pagination">
                <button onClick={() => setPage(page - 1)} disabled={page === 1}>Prev</button>
                <span>Page {page}</span>
                <button onClick={() => setPage(page + 1)} disabled={!hasNext}>Next</button>
              </div>
            </>
          )}
        </main>
      </div>
       {quickView && (
        <div className="modal" onClick={() => setQuickView(null)}>
          <div className="modal-content" onClick={(e) => e.stopPropagation()}>
            <h2>{quickView.pname}</h2>
            <p>₹{quickView.price}</p>
            <button onClick={() => navigate(`/product/${quickView.id}`)}>
              View Full Details
            </button>
          </div>
        </div>
      )}

    </div>
  );
}

export default ProductList;