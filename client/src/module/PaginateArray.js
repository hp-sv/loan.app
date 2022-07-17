const PaginateArray = (array, pageSize, pageNumber) => {
  return array.slice((pageNumber - 1) * pageSize, pageNumber * pageSize);
};
export default PaginateArray;
