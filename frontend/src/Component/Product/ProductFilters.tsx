
type Filters = {
  pname: string;
  minPrice: string;
  maxPrice: string;
};

type ProductFiltersProps = {
  filters: Filters;
  setFilters: (val: Filters) => void;
  onApply: () => void;
};

export default function ProductFilters({
  filters,
  setFilters,
  onApply,
 
}: ProductFiltersProps) {

  const handleChange = (key: keyof Filters, value: string) => {
    setFilters({
      ...filters,
      [key]: value,
    });
  };

  return (
    <div className="filters">
      <input
        type="text"
        placeholder="Product name"
        value={filters.pname}
        onChange={(e) => handleChange("pname",e.target.value)}
      />
      <input
        type="number"
        placeholder="Min Price"
        value={filters.minPrice}
        onChange={(e) => handleChange("minPrice",e.target.value)}
      />
      <input
        type="number"
        placeholder="Max Price"
        value={filters.maxPrice}
        onChange={(e) => handleChange("maxPrice",e.target.value)}
      />
      <button onClick={onApply}>Apply Filter</button>
    </div>
  );
}