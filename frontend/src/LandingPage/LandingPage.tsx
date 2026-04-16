import { useEffect ,useState} from "react";
import { useGetProductsQuery } from "../Component/Product/ProductService";
import { ShoppingCart, Search } from "lucide-react";
import { useNavigate ,useSearchParams} from "react-router-dom";

 function LandingPage() {
    const navigate = useNavigate();
    const [searchParams] = useSearchParams();
    const [page, setPage] = useState(1);
  const { data: products =[], isLoading } = useGetProductsQuery({
         pageNumber: 1,
        pageSize: 5,
    }
  );

   const [filters, setFilters] = useState({
      search: searchParams.get("name") || "",
      minPrice: "",
      maxPrice: "",
      inStockOnly: false,
    });
  
     const handleFilterChange = (key: string, value: any) =>
    setFilters((prev) => ({ ...prev, [key]: value }));

  const applyFilters = () => {
    setPage(1);
    navigate(`/products?name=${filters.search}`);
  };

  return (
    <div className="min-h-screen bg-gray-50">
      
      <nav className="flex items-center justify-between px-8 py-4 bg-white shadow-md">
        <h1 className="text-2xl font-bold text-blue-600">ORMS</h1>

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

        <div className="flex gap-6 items-center">
          <button className="font-medium" onClick={() => navigate("/login")}>Login</button>
          <button className="font-medium" onClick={() => navigate("/orders")}>Orders</button>
          <ShoppingCart
  className="cursor-pointer"
  onClick={() => navigate("/cart")}
/>
        </div>
      </nav>

     
      <section className="bg-gradient-to-r from-blue-500 to-indigo-600 text-white p-10 rounded-b-3xl">
        <h2 className="text-4xl font-bold mb-4">Manage Orders Seamlessly</h2>
        <p className="text-lg mb-6">
          Fast, reliable and scalable order management system for your business.
        </p>
        <button className="bg-white text-blue-600 px-6 py-3 rounded-xl font-semibold"
        onClick={() => navigate("/products")}>
          Get Started
        </button>
      </section>

      
      <section className="p-8">
        <h3 className="text-2xl font-semibold mb-6">Categories</h3>
        <div className="grid grid-cols-2 md:grid-cols-4 gap-6">
          {["Electronics"].map((cat) => (
            <div
              key={cat}
               onClick={() => navigate(`/products?name=${cat}`)}
              className="bg-white p-6 rounded-2xl shadow hover:shadow-lg cursor-pointer text-center"
            >
              <p className="font-medium">{cat}</p>
            </div>
          ))}
        </div>
      </section>

      
      <section className="p-8">
        <h3 className="text-2xl font-semibold mb-6">Top Products</h3>

        {isLoading ? (
          <p>Loading...</p>
        ) : (
          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
            {products?.map((p) => (
              <div
                key={p.id}
                className="bg-white p-4 rounded-2xl shadow hover:shadow-lg transition"
              >
                <img
                  src={p.imageUrl || "https://via.placeholder.com/150"}
                  alt={p.pname}
                  className="h-40 w-full object-cover rounded-xl mb-3"
                />
                <h4 className="font-semibold">{p.pname}</h4>
                <p className="text-gray-500">₹{p.price}</p>

                <button className="mt-3 w-full bg-blue-600 text-white py-2 rounded-xl">
                  Add to Cart
                </button>
              </div>
            ))}
          </div>
        )}
      </section>

     
      <section className="p-8">
        <div className="bg-indigo-100 p-8 rounded-3xl flex justify-between items-center">
          <div>
            <h3 className="text-2xl font-bold">Track Orders Easily</h3>
            <p className="text-gray-600">
              Real-time updates and smooth tracking experience.
            </p>
          </div>
          <button className="bg-indigo-600 text-white px-6 py-3 rounded-xl">
            View Orders
          </button>
        </div>
      </section>

      
      <footer className="bg-gray-900 text-white p-6 text-center">
        <p>© 2026 ORMS. All rights reserved.</p>
      </footer>
    </div>
  );
}

export default LandingPage;