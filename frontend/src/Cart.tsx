import { useEffect, useState } from "react";
import "./Cart.css";

export default function Cart() {
  const [cart, setCart] = useState<any[]>([]);

  useEffect(() => {
    const storedCart = JSON.parse(localStorage.getItem("cart") || "[]");
    setCart(storedCart);
  }, []);

  const handleRemove = (index: number) => {
    const updated = [...cart];
    updated.splice(index, 1);
    setCart(updated);
    localStorage.setItem("cart", JSON.stringify(updated));
  };

  const handleOrder = (item: any) => {
    alert(`Order placed for ${item.pname}`);
  };

  return (
    <div className="cart-container">
      <h2 className="cart-title">Your Cart</h2>

      {cart.length === 0 ? (
        <p className="empty-cart">Your cart is empty</p>
      ) : (
        <div className="cart-list">
          {cart.map((item, index) => (
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