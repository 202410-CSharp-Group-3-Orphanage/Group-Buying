namespace Forestage.Models.ViewModels.Paging
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount, string sortColumn, string sortDirection)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            SortColumn = sortColumn;
            SortDirection = sortDirection;
        }
    }
}
