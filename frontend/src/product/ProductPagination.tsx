
type ProductPaginationProps = {
  page: number;                  
  setPage: (val: number) => void; 
  hasNext: boolean;               
};


function ProductPagination({ page, setPage, hasNext }: ProductPaginationProps) {
  return (
    <div >
      <button onClick={() => setPage(page - 1)} disabled={page === 1}>
        Prev
      </button>
      <span> Page {page} </span>
      <button onClick={() => setPage(page + 1)} disabled={!hasNext}>
        Next
      </button>
    </div>
  );
}

export default ProductPagination;