import "./ProductCard.css";
import { useDispatch } from "react-redux";
import { addToCart, placeOrder } from "../order/OrderSlice";

export type Product = {
  id: number;
  pname: string;
  price: number;
  stock: number;
  imageUrl?: string;
};

function ProductCard({ product }: { product: Product }) {
  const dispatch = useDispatch();

  const handleAddToCart = () => {
    dispatch(addToCart({
      id: product.id,
      name: product.pname, 
      price: product.price
    }));

    alert("Product added to cart!");
  };

  const handleOrderNow = () => {
    dispatch(placeOrder({
      id: Date.now(),
      userName: "",
      orderDate: new Date().toISOString(),
      totalAmount: product.price,
      items: [{
        id: product.id,
        name: product.pname,
        price: product.price
      }]
    }));

    alert(`Order placed for ${product.pname}`);
  };

  return (
    <div className="card">
      <div className="image-container">
        <img
          src={product.imageUrl || "https://via.placeholder.com/150"}
          alt={product.pname}
        />
      </div>

      <div className="info">
        <p className="name">{product.pname}</p>
        <p className="price">₹{product.price}</p>
        <p>{product.stock > 0 ? "In Stock" : "Out of Stock"}</p>

        <button onClick={handleAddToCart} disabled={product.stock === 0}>
          Add to Cart
        </button>

        <button onClick={handleOrderNow} disabled={product.stock === 0}>
          Order Now
        </button>
      </div>
    </div>
  );
}

export default ProductCard;