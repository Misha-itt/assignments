import { useEffect, useState } from "react";
import OrderCard, { Order } from "./OrderCard";
import "./OrderList.css";

function OrderList() {
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  // Pagination
  const [page, setPage] = useState(1);
  const pageSize = 5;

  // Filters
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [userName, setUserName] = useState("");

  const loadOrders = async () => {
    try {
      setLoading(true);
      setError("");

      const query = new URLSearchParams({
        pageNumber: page.toString(),
        pageSize: pageSize.toString(),
        ...(startDate && { startDate }),
        ...(endDate && { endDate }),
        ...(userName && { userName }),
      }).toString();

      const res = await fetch(`https://localhost:62301/api/Orders?${query}`);
      if (!res.ok) throw new Error("Failed to fetch orders");

      const data: Order[] = await res.json();
      setOrders(Array.isArray(data) ? data : []);
    } catch (err: any) {
      setError(err.message || "Something went wrong");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadOrders();
  }, [page]);

  const handleApplyFilters = () => {
    setPage(1); // reset page when applying filters
    loadOrders();
  };

  const hasNext = orders.length === pageSize;

  return (
    <div className="order-page">
      <h2>Orders</h2>

      {/* Filters */}
      <div className="order-filters">
        <label>
          Start Date:
          <input
            type="date"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
          />
        </label>

        <label>
          End Date:
          <input
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
          />
        </label>

        <label>
          User Name:
          <input
            type="text"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            placeholder="Enter user"
          />
        </label>

        <button onClick={handleApplyFilters}>Apply Filters</button>
      </div>

      {/* Loading/Error */}
      {loading && <p>Loading...</p>}
      {error && <p className="error">{error}</p>}

      {/* Orders List */}
      {!loading && !error && orders.length === 0 && <p>No orders found</p>}

      <div className="orders-grid">
        {orders.map((o) => o && <OrderCard key={o.id} order={o} />)}
      </div>

      {/* Pagination */}
      <div className="pagination">
        <button onClick={() => setPage(page - 1)} disabled={page === 1}>
          Prev
        </button>
        <span> Page {page} </span>
        <button onClick={() => setPage(page + 1)} disabled={!hasNext}>
          Next
        </button>
      </div>
    </div>
  );
}

export default OrderList;