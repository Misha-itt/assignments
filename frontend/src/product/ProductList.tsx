import { useState } from "react";
import ProductCard, { Product } from "./ProductCard";
import { useGetProductsQuery } from "./ProductService";
import { useNavigate } from "react-router-dom";
import { NAVBAR, SIDEBAR, CONTENT, PAGINATION, PAGE } from "./ProductConstant";
import "./ProductList.css";

function ProductList() {
  const navigate = useNavigate();
  const [page, setPage] = useState(1);
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

  const handleFilterChange = (key: string, value: any) =>
    setFilters((prev) => ({ ...prev, [key]: value }));

  const handleApplyFilters = () => setPage(1);

  const handleAction = (action: string) => {
    if (action === "search") handleApplyFilters();
    if (action === "cart") navigate("/cart");
  };

  const hasNext = products.length === pageSize;

  return (
    <div className="page">
      <div className="navbar">
        <h2 className="logo">{NAVBAR.title}</h2>
        <div>
          <input
            type="text"
            placeholder={NAVBAR.searchPlaceholder}
            value={filters.search}
            onChange={(e) => handleFilterChange("search", e.target.value)}
            onKeyDown={(e) => e.key === "Enter" && handleApplyFilters()}
          />
          {NAVBAR.buttons.map((btn) => (
            <button key={btn.action} onClick={() => handleAction(btn.action)}>
              {btn.label}
            </button>
          ))}
        </div>
        <button className="login-btn" onClick={() => navigate("/login")}>
          {NAVBAR.loginButton}
        </button>
      </div>

      <div className="main">
        <div className="sidebar">
          <h3>{SIDEBAR.title}</h3>

          <div className="filter">
            <p><strong>Price</strong></p>
            {SIDEBAR.priceFields.map((f) => (
              <input
                key={f.key}
                type="number"
                placeholder={f.placeholder}
                value={(filters as any)[f.key]}
                onChange={(e) => handleFilterChange(f.key, e.target.value)}
              />
            ))}
          </div>

          <div className="filter">
            <p><strong>Availability</strong></p>
            <label>
              <input
                type="checkbox"
                checked={filters.inStockOnly}
                onChange={(e) =>
                  handleFilterChange(SIDEBAR.availabilityField.key, e.target.checked)
                }
              />
              {SIDEBAR.availabilityField.label}
            </label>
          </div>

          <button onClick={handleApplyFilters}>{SIDEBAR.applyButton}</button>
        </div>

        <div className="content">
          <h2 className="title">{CONTENT.title}</h2>

          {isLoading && <p>{CONTENT.loadingMessage}</p>}
          {error && <p className="error">Failed to fetch products</p>}

          {!isLoading && products.length === 0 && !error && (
            <p className="empty">{CONTENT.emptyMessage}</p>
          )}

          {!isLoading && products.length > 0 && (
            <>
              <div className="grid">
                {products.map((p) => (
                  <ProductCard key={p.id} product={p} />
                ))}
              </div>

              <div className="pagination">
                <button onClick={() => setPage(page - 1)} disabled={page === 1}>
                  {PAGINATION.prev}
                </button>
                <span>{PAGINATION.pageLabel(page)}</span>
                <button onClick={() => setPage(page + 1)} disabled={!hasNext}>
                  {PAGINATION.next}
                </button>
              </div>
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default ProductList;