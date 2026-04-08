import axios from "axios";
import { useEffect, useState } from "react";
import "./OrderForm.css";

function OrderFormm() {
  const [products, setProducts] = useState([]);

  const [customerName, setCustomerName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  const [productId, setProductId] = useState("");
  const [quantity, setQuantity] = useState(1);
  const [paymentMethod,setPaymentMethod] = useState("Cash on Delivery");
  const [orders, setOrders] = useState([]);


  useEffect(() => {
    axios.get("https://localhost:62301/api/Product",orders)
      .then(res => setProducts(res.data))
      .catch(err => console.error(err));
  }, []);


  const selectedProduct = products.find(
    p => p.id === Number(productId)
  );

  const totalPrice = selectedProduct ? selectedProduct.price * quantity : 0;

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!customerName || !email || !address || !selectedProduct) {
      alert("Please fill all fields");
      return;
    }

    const order = {
      customerName,
      email,
      address,
      productId: selectedProduct.id,
      quantity: Number(quantity),
      paymentMethod,
      totalPrice,
      orderDate: new Date()
    };

    axios.post("https://localhost:62301/api/Orders", order)
      .then(() => {
        alert("Order placed successfully!");

        setOrders([
          ...orders,
          { ...order, productName: selectedProduct.pname }
        ]);

       
        setCustomerName("");
        setEmail("");
        setAddress("");
        setProductId("");
        setQuantity(1);
        setPaymentMethod("Cash on Delivery");
      })
      .catch(err => console.error(err));
  };

  return (
    <div className="container">
      <h2>Place Your Order</h2>

      <form onSubmit={handleSubmit} className="form">

        <div className="form-group">
          <label>Name</label>
          <input
            type="text"
            value={customerName}
            onChange={(e) => setCustomerName(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label>Email</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label>Address</label>
          <textarea
            value={address}
            onChange={(e) => setAddress(e.target.value)}
          />
        </div>

       
        <div className="form-group">
          <label>Product</label>
          <select
            value={productId}
            onChange={(e) => setProductId(e.target.value)}
          >
            <option value="">-- Select Product --</option>
            {products.map(p => (
              <option key={p.id} value={p.id}>
                {p.pname} 
              </option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Quantity</label>
          <input
            type="number"
            min="1"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
          />
        </div>

        <div className="form-group">
          <label>Payment Method</label>
          <select
            value={paymentMethod}
            onChange={(e) => setPaymentMethod(e.target.value)}
          >
            <option>Cash on Delivery</option>
            <option>UPI</option>
            <option>Card</option>
          </select>
        </div>

        <div className="total">
          <b>Total Price:</b> ₹{totalPrice}
        </div>

        <button type="submit" className="btn">
          Place Order
        </button>
      </form>

     
     
   
      {orders.length > 0 && (
        <div className="order-list">
          <h3>Orders</h3>
          {orders.map((o) => (
            <div key={o.orderDate} className="card">
              {o.customerName} ordered {o.productName}  
              (Qty: {o.quantity}) - ₹{o.totalPrice}
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default OrderFormm;