
import ProductList from './Component/Product/ProductList'
import OrderList from './Component/Order/OrderList'
import { Routes, Route } from "react-router-dom";
import Cart from "./Component/Cart/Cart";
import Login from "./Component/LoginPages/Login";
import Register from './Component/LoginPages/Register';
import ProtectedRoute from './ProtectedRoute';
import PlaceOrder from "./Component/Order/PlaceOrder";
import LandingPage from "./LandingPage/LandingPage";



function App() {
 

  return (
    <>
      <Routes>
        <Route path="/" element={<LandingPage />} />
      <Route path="/products" element={<ProductList />} />
      <Route path="/orders"element = {<OrderList/>}/>
      <Route path="/cart" element={
        <ProtectedRoute> <Cart /></ProtectedRoute>
      }
        /> 
         <Route
        path="/checkout"
        element={
          <ProtectedRoute>
            <PlaceOrder />
          </ProtectedRoute>
        }
      />
       <Route path="/login" element={<Login />} />
       <Route path="/register" element={<Register/>} />
    </Routes>
    </>
  )
}

export default App
