import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store";
import { toast } from "react-toastify";
import { CartItem, placeOrder } from "./OrderSlice";
import { useCreateOrderMutation } from "./OrderApi";
import {TYPE, VALUE} from "./OrderConstant"


import { PaymentMethod } from "./OrderCard";

type CreateOrderRequest = {
      userName: string;
      totalAmount: number;
      items: CartItem[];
      paymentMethod: PaymentMethod;
    };

function PlaceOrder() {
  const [createOrder, { isLoading }] = useCreateOrderMutation();
  const cart = useSelector((state: RootState) => state.order.cart);
  const dispatch = useDispatch();

  const [paymentMethod, setPaymentMethod] = useState<PaymentMethod>("COD");
  const [loading, setLoading] = useState(false);

  const total = cart.reduce((sum, item) => sum + item.price, 0);

  const handlePlaceOrder = async () => {
    if (cart.length === 0) return;

    setLoading(true);

    type PaymentMethod = "COD" | "UPI" | "CARD";

    

    const orderData: CreateOrderRequest = {
      userName: "",
      totalAmount: total,
      items: cart,
      paymentMethod: paymentMethod,
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
            type= {TYPE.selecttype}
            value={VALUE.value1}
            checked={paymentMethod === VALUE.value1}
            onChange={(e) => setPaymentMethod(e.target.value as PaymentMethod)}
          />
          Cash on Delivery
        </label>

        <label>
          <input
            type = {TYPE.selecttype}
            value={VALUE.value3}
            checked={paymentMethod === VALUE.value3}
            onChange={(e) => setPaymentMethod(e.target.value as PaymentMethod)}
          />
          UPI
        </label>

        <label>
          <input
            type={TYPE.selecttype}
            value={VALUE.value2}
            checked={paymentMethod === VALUE.value2}
            onChange={(e) => setPaymentMethod(e.target.value as PaymentMethod)}
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
