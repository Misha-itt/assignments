import "./ProductCard.css";

export type Product = {
  id: number;
  pname: string;
  price: number;
  stock: number;
  imageUrl?: string; 
};

function ProductCard({ product }: { product: Product }) {

  const handleAddToCart = () => {
    const existingCart = JSON.parse(localStorage.getItem("cart") || "[]");

    const updatedCart = [...existingCart, product];

    localStorage.setItem("cart", JSON.stringify(updatedCart));

    alert("Product added to cart!");
  };


  const handleOrderNow = () => {
    const orders = JSON.parse(localStorage.getItem("orders") || "[]");

    const updatedOrders = [...orders, product];

    localStorage.setItem("orders", JSON.stringify(updatedOrders));

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

        <p className="stock">
          {product.stock > 0 ? "In Stock" : "Out of Stock"}
        </p>

        <div className="rating"> 4.2</div>

        <div className="actions">
          <button
            className="add-btn"
            onClick={handleAddToCart}
            disabled={product.stock === 0}
          >
            Add to Cart
          </button>

          <button
            className="order-btn"
            onClick={handleOrderNow}
            disabled={product.stock === 0}
          >
            Order Now
          </button>
        </div>

      </div>
    </div>
  );
}

export default ProductCard;