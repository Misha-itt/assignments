
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Order } from './OrderCard';
import { API_BASE_URL } from '../../config'; 

export const OrderApi= createApi({
  reducerPath: 'orderApi',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
   tagTypes: ["Orders"],
  endpoints: (builder) => ({
    getOrders: builder.query<Order[], string>({
      query: (query) => `Order?${query}`, 
      providesTags: ["Orders"],
    }),

    createOrder: builder.mutation<Order, Partial<Order>>({
      query: (body) => ({
        url: "Orders", 
        method: "POST",
        body,
      }),
       invalidatesTags: ["Orders"],
    }),
  }),
});

export const { useGetOrdersQuery ,   useCreateOrderMutation} = OrderApi;