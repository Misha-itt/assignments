import { useState } from 'react'
import ProductList from './product/ProductList'
import OrderList from './order/OrderList'
import { Routes, Route } from "react-router-dom";
import Cart from "./Cart";
import Login from "./LoginPages/Login";
import Register from './LoginPages/Register';
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
