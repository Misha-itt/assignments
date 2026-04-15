import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store";
import { toast } from "react-toastify";
import { placeOrder } from "./OrderSlice";
import { useCreateOrderMutation } from "./OrderApi";

import "./PlaceOrder.css";

function PlaceOrder() {
    const [createOrder, { isLoading }] = useCreateOrderMutation();
  const cart = useSelector((state: RootState) => state.order.cart);
  const dispatch = useDispatch();

  const [paymentMethod, setPaymentMethod] = useState("COD");
  const [loading, setLoading] = useState(false);

  const total = cart.reduce((sum, item) => sum + item.price, 0);


  const handlePlaceOrder = async () => {
    if (cart.length === 0) return;

    setLoading(true);

    
   const orderData = {
        
          id: Date.now(),
          userName: "Misha",
          orderDate: new Date().toISOString(),
          totalAmount: total,
          items: cart,
          paymentMethod,
          status: paymentMethod === "COD" ? "Pending" : "Paid"
        };

        try {
    const response = await createOrder(orderData).unwrap();
     if (paymentMethod !== "COD") {
         toast.info("Processing payment...");
    }

    toast.success("Order placed successfully ");


  } catch (err) {
    toast.error("Order failed ");
  }
};
    

     

  return (
    <div className="place-order">
      <h2>Checkout</h2>

      <h3>Total: ₹{total}</h3>

     
      <div className="payment-method">
        <label>
          <input
            type="radio"
            value="COD"
            checked={paymentMethod === "COD"}
            onChange={(e) => setPaymentMethod(e.target.value)}
          />
          Cash on Delivery
        </label>

        <label>
          <input
            type="radio"
            value="UPI"
            checked={paymentMethod === "UPI"}
            onChange={(e) => setPaymentMethod(e.target.value)}
          />
          UPI
        </label>

        <label>
          <input
            type="radio"
            value="CARD"
            checked={paymentMethod === "CARD"}
            onChange={(e) => setPaymentMethod(e.target.value)}
          />
          Card
        </label>
      </div>

      <button onClick={handlePlaceOrder} disabled={loading}>
        {loading ? "Processing..." : "Place Order"}
      </button>
    </div>
  );
}

export default PlaceOrder;