
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Product } from './ProductCard';
import { API_BASE_URL } from '../../config'; 


 export type ProductQueryParams = {
  pageNumber: number;
  pageSize: number;
  name?: string;
  minPrice?: number;
  maxPrice?: number;
  inStock?: boolean;
};

export const ProductService = createApi({
  reducerPath: 'ProductService',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getProducts: builder.query<Product[], ProductQueryParams>({
      query: (params) =>({ url : "Product", params, 
    }),
  }),
}),
});

export const { useGetProductsQuery } = ProductService;
