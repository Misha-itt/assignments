import api from "./api";
import type { Product } from "./product/ProductCard";

export const getProducts = async (): Promise<Product[]> => {
  try {
    const res = await api.get("/Product"); 
    console.log("API response:", res.data); 
    return Array.isArray(res.data) ? res.data : [];
  } catch (err) {
    console.error("Failed to fetch products:", err);
    return [];
  }
};