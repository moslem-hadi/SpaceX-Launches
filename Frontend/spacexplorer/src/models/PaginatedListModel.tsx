export default interface PaginatedListModel<T> {
  pageNumber: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
  items: T[];
}
