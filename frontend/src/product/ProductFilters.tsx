type ProductFiltersProps = {
  pname: string;
  setPname: (val: string) => void;
  minPrice: string;
  setMinPrice: (val: string) => void;
  maxPrice: string;
  setMaxPrice: (val: string) => void;
  onApply: () => void;
};

export default function ProductFilters({
  pname,
  setPname,
  minPrice,
  setMinPrice,
  maxPrice,
  setMaxPrice,
  onApply,
}: ProductFiltersProps) {
  return (
    <div className="filters">
      <input
        type="text"
        placeholder="Product name"
        value={pname}
        onChange={(e) => setPname(e.target.value)}
      />
      <input
        type="number"
        placeholder="Min Price"
        value={minPrice}
        onChange={(e) => setMinPrice(e.target.value)}
      />
      <input
        type="number"
        placeholder="Max Price"
        value={maxPrice}
        onChange={(e) => setMaxPrice(e.target.value)}
      />
      <button onClick={onApply}>Apply Filter</button>
    </div>
  );
}