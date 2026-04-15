import { useState } from 'react'
import ProductList from './Component/Product/ProductList'
import OrderList from './Component/Order/OrderList'
import { Routes, Route } from "react-router-dom";
import Cart from "./Component/Cart/Cart";
import Login from "./Component/LoginPages/Login";
import Register from './Component/LoginPages/Register';
import ProtectedRoute from './ProtectedRoute';



function App() {
 

  return (
    <>
      <Routes>
      <Route path="/" element={<ProductList />} />
      <Route path="/orders"element = {<OrderList/>}/>
      <Route path="/cart" element={
        <ProtectedRoute> <Cart /></ProtectedRoute>
      }
        /> 
       <Route path="/login" element={<Login />} />
       <Route path="/register" element={<Register/>} />
    </Routes>
    </>
  )
}

export default App
