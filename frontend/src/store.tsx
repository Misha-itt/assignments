import { configureStore } from "@reduxjs/toolkit";
import { api } from "./api";
import authReducer from "./AuthSlice";
import { ProductService } from "./Component/Product/ProductService"
import orderReducer from "./Component/Order/OrderSlice";

export const store = configureStore({
  reducer: {
    [api.reducerPath]: api.reducer,
    [ProductService.reducerPath]: ProductService.reducer,
    auth: authReducer,
    order: orderReducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(api.middleware)
                        .concat(ProductService.middleware),
});


export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;