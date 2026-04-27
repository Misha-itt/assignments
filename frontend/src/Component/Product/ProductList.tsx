import { useState, useMemo, useEffect } from "react";
import ProductCard, { Product } from "./ProductCard";
import { useGetProductsQuery } from "./ProductService";
import { useNavigate, useSearchParams } from "react-router-dom";
import { NAVBAR, SIDEBAR, PAGE,PRICE, CONTENT } from "./ProductConstant";
import { ShoppingCart, Search } from "lucide-react";
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
  const [searchParams] = useSearchParams();

  const [page, setPage] = useState(1);
  const [sort, setSort] = useState("default");
  const [wishlist, setWishlist] = useState<number[]>([]);
  const [quickView, setQuickView] = useState<Product | null>(null);

  const [filters, setFilters] = useState({
    search: searchParams.get("name") || "",
    minPrice: "",
    maxPrice: "",
    inStockOnly: false,
  });

  const pageSize = PAGE.Pagesize;

  useEffect(() => {
    const name = searchParams.get("name");
    if (name) {
      setFilters((prev) => ({ ...prev, search: name }));
      setPage(1);
    }
  }, [searchParams]);

  const queryParams = {
    pageNumber: page,
    pageSize: pageSize,
    name: filters.search || undefined,
    minPrice: filters.minPrice !== "" ? Number(filters.minPrice) : undefined,
    maxPrice: filters.maxPrice !== "" ? Number(filters.maxPrice) : undefined,
    inStock: filters.inStockOnly ? true : undefined,
  };

  const {
    data: products = [],
    error,
    isLoading,
  } = useGetProductsQuery(queryParams);

  
  const sortedProducts = useMemo(() => {
    let data = [...products];

    if (sort === "low") data.sort((a, b) => a.price - b.price);
    if (sort === "high") data.sort((a, b) => b.price - a.price);

    return data;
  }, [products, sort]);

  const toggleWishlist = (id: number) => {
    setWishlist((prev) =>
      prev.includes(id) ? prev.filter((x) => x !== id) : [...prev, id],
    );
  };

  const handleFilterChange = (key: string, value: any) =>
    setFilters((prev) => ({ ...prev, [key]: value }));

  const applyFilters = () => {
    setPage(1);
    navigate(`/products?name=${filters.search}`);
  };

  const hasNext = products.length === pageSize;

  return (
    <div className="plp-page">
      <nav className="flex items-center justify-between px-8 py-4 bg-white shadow-md">
        <h1
          className="text-2xl font-bold text-blue-600 cursor-pointer"
          onClick={() => navigate("/")}
        >
          ORMS
        </h1>

        <div className="flex items-center bg-gray-100 px-4 py-2 rounded-xl w-1/2">
          <Search size={18} />
          <input
            type="text"
            placeholder="Search products..."
            className="bg-transparent outline-none ml-2 w-full"
            value={filters.search}
            onChange={(e) => handleFilterChange("search", e.target.value)}
            onKeyDown={(e) => {
              if (e.key === "Enter") applyFilters();
            }}
          />
        </div>
        <select
          className="sort"
          value={sort}
          onChange={(e) => setSort(e.target.value)}
        >
          <option value="default">{PRICE.sort}</option>
          <option value="low">{PRICE.low}</option>
          <option value="high">{PRICE.high}</option>
        </select>

        <div className="flex gap-6 items-center">
          <button className="font-medium" onClick={() => navigate("/login")}>
            {NAVBAR.loginButton}
          </button>

          <button className="font-medium" onClick={() => navigate("/orders")}>
            {NAVBAR.orderbutton}
          </button>

          <ShoppingCart
            className="cursor-pointer"
            onClick={() => navigate("/cart")}
          />
        </div>
      </nav>

      <div className="plp-body">
        <aside className="plp-sidebar">
          <h3>{SIDEBAR.title}</h3>

          <div className="filter-box">
            <p>
              <strong>Price</strong>
            </p>
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
                onChange={(e) =>
                  handleFilterChange(
                    SIDEBAR.availabilityField.key,
                    e.target.checked,
                  )
                }
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

          {error && <div className="error">{CONTENT.failed}</div>}

          {!isLoading && sortedProducts.length === 0 && (
            <div className="empty">{CONTENT.emptyMessage}</div>
          )}

          {!isLoading && sortedProducts.length > 0 && (
            <>
              <div className="grid">
                {sortedProducts.map((p) => (
                  <div className="product-wrapper" key={p.id}>
                    <div
                      className="wishlist"
                      onClick={() => toggleWishlist(p.id)}
                    >
                      {wishlist.includes(p.id) ? "❤️" : "🤍"}
                    </div>

                    <div onClick={() => setQuickView(p)}>
                      <ProductCard product={p} />
                    </div>
                  </div>
                ))}
              </div>

              <div className="pagination">
                <button onClick={() => setPage(page - 1)} disabled={page === 1}>
                  Prev
                </button>

                <span>Page {page}</span>

                <button onClick={() => setPage(page + 1)} disabled={!hasNext}>
                  Next
                </button>
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
