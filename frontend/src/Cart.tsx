
import "./Cart.css";
import { toast } from "react-toastify";
import { useSelector, useDispatch } from "react-redux";
import { removeFromCart, placeOrder } from "./order/OrderSlice";
import { RootState } from "./store";


export interface CartItem {
  id: number;
  name: string;
  price: number;
}

export default function Cart() {
  const cart = useSelector((state: RootState) => state.order.cart);
  const dispatch = useDispatch();
 

  const handleRemove = (index: number) => {
   dispatch(removeFromCart(index));
    toast.info("Item removed from cart");
  };



  const handleOrder = (item: CartItem) => {
  dispatch(placeOrder({
    id: Date.now(),
    userName: "",
    orderDate: new Date().toISOString(),
    totalAmount: item.price,
    items: [item]
  }));

  toast.success(`Order placed for ${item.name}`);
};

  return (
    <div className="cart-container">
      <h2 className="cart-title">Your Cart</h2>

      {cart.length === 0 ? (
        <p className="empty-cart">Your cart is empty</p>
      ) : (
        <div className="cart-list">
          {cart.map((item:any ,index:number) => (
            <div key={index} className="cart-item">
              <div className="cart-info">
                <h4>{item.pname}</h4>
                <p>₹{item.price}</p>
              </div>

              <div>
                <button
                  className="order-btn"
                  onClick={() => handleOrder(item)}
                >
                  Order
                </button>

                <button
                  className="remove-btn"
                  onClick={() => handleRemove(index)}
                >
                  Remove
                </button>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}