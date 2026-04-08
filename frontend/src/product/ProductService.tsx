export const getProducts = async (query: string) => {
  const res = await fetch(`https://localhost:62301/api/Product?${query}`);

  if (!res.ok) {
    throw new Error("Failed to fetch products");
  }

  return res.json();
};