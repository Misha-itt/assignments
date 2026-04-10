import { useEffect, useState } from "react";
import OrderCard, { Order } from "./OrderCard";
import { useGetOrdersQuery } from "./OrderApi"; 
import "./OrderList.css";

function OrderList() {
  // const [orders, setOrders] = useState<Order[]>([]);
  // const [loading, setLoading] = useState(false);
  // const [error, setError] = useState("");


  const [page, setPage] = useState(1);
  const pageSize = 5;


  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [userName, setUserName] = useState("");



      const query = new URLSearchParams({
        pageNumber: page.toString(),
        pageSize: pageSize.toString(),
        ...(startDate && { startDate }),
        ...(endDate && { endDate }),
        ...(userName && { userName }),
      }).toString();

      
   const {
    data: orders = [],
    isLoading: loading,
    error
  } = useGetOrdersQuery(query);

    

  const handleApplyFilters = () => {
    setPage(1);
  };

  const hasNext = orders.length === pageSize;

  return (
    <div className="order-page">
      <h2>Orders</h2>

   
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

     
      {loading && <p>Loading...</p>}
      {error && <p className="error">Failed to fetch</p>}

     
      {!loading && !error && orders.length === 0 && <p>No orders found</p>}

      <div className="orders-grid">
        {orders.map((o) => o && <OrderCard key={o.id} order={o} />)}
      </div>

     
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