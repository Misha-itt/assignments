import { configureStore } from "@reduxjs/toolkit";
import { api } from "./api";
import authReducer from "./AuthSlice";
import { ProductService } from "./Component/Product/ProductService"
import orderReducer from "./Component/Order/OrderSlice";
import { OrderApi } from "./Component/Order/OrderApi";

export const store = configureStore({
  reducer: {
    [api.reducerPath]: api.reducer,
    [ProductService.reducerPath]: ProductService.reducer,
    [OrderApi.reducerPath]: OrderApi.reducer,
    auth: authReducer,
    order: orderReducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(api.middleware)
                        .concat(ProductService.middleware)
                        .concat(OrderApi.middleware),
});


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;