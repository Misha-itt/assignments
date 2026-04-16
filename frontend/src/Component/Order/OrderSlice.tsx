
import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import  {Order} from "./OrderCard"

export type CartItem={
    id: number;
  name: string;
  price: number;
};



interface OrderState{
    cart: CartItem[];
    order : Order[];
}

const initialState : OrderState = {
  cart: [],
  order: []
};

const orderSlice = createSlice({
  name: "order",
  initialState,
  reducers: {
    addToCart: (state, action: PayloadAction<CartItem>) => {
      state.cart.push(action.payload);
    },


    removeFromCart: (state, action :  PayloadAction<number>)  => {
      state.cart = state.cart.filter(
        item => item.id !== action.payload
      );
    },

    placeOrder: (state, action :  PayloadAction<Order>) => {
      state.order.push(action.payload);
      state.cart = []; 
    }
  }
});

export const { addToCart, removeFromCart, placeOrder } = orderSlice.actions;
export default orderSlice.reducer;