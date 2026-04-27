
export const NAVBAR = {
  title: "ORMS",
  searchPlaceholder: "Search for products...",
  buttons: [
    { label: "Search", action: "search" },
    { label: "Go to Cart", action: "cart" },
  ],
  loginButton: "Login",
  orderbutton : "Order"
};

export const SIDEBAR = {
  title: "Filters",
  priceFields: [
    { key: "minPrice" as const, placeholder: "Min Price" },
    { key: "maxPrice" as const, placeholder: "Max Price" },
  ],
  availabilityField: { key: "inStockOnly" as const, label: "In Stock Only" },
  applyButton: "Apply Filters",
};

export const CONTENT = {
  title: "Products",
  emptyMessage: "No products found",
  loadingMessage: "Loading...",

  failed : "Failed to load products"
};

export const PAGINATION = {
  prev: "Prev",
  next: "Next",
  pageLabel: (page: number) => `Page ${page}`,
};

export const PAGE ={
  Pagesize : 20,

};

export const PRICE ={
  low : "Low - High",
  high : "High - Low",
  sort :  "sort"
}