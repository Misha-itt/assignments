import { useState } from 'react'
import ProductList from './product/ProductList'
import OrderFormm from './order/OrderFormm'
import OrderList from './order/OrderList'
import { Routes, Route } from "react-router-dom";
import Cart from "./Cart";
import Login from "./LoginPages/Login";
import Register from './LoginPages/Register';



function App() {
 

  return (
    <>
      <Routes>
      <Route path="/" element={<ProductList />} />
      <Route path="/cart" element={<Cart />} /> 
       <Route path="/login" element={<Login />} />
       <Route path="/register" element={<Register/>} />
    </Routes>
    </>
  )
}

export default App
