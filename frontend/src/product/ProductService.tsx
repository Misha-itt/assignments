
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Product } from './ProductCard';
import { API_BASE_URL } from '../config'; 

export const ProductService = createApi({
  reducerPath: 'ProductService',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getProducts: builder.query<Product[], string>({
      query: (query) => `Product?${query}`, 
    }),
  }),
});

export const { useGetProductsQuery } = ProductService;