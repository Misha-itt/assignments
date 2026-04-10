
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Order } from './OrderCard';
import { API_BASE_URL } from '../config'; 

export const OrderApi= createApi({
  reducerPath: 'orderApi',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getOrders: builder.query<Order[], string>({
      query: (query) => `Order?${query}`, 
    }),

    createOrder: builder.mutation<Order, Partial<Order>>({
      query: (body) => ({
        url: "Orders", 
        method: "POST",
        body,
      }),
    }),
  }),
});

export const { useGetOrdersQuery ,   useCreateOrderMutation} = OrderApi;