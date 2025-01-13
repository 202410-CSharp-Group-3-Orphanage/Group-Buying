using Forestage.Models.Services;

namespace Forestage.Models.Infra
{
    public class PagedList<T, TSortInfo>
    {
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public TSortInfo SortInfo { get; set; }

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount, TSortInfo sortInfo)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            SortInfo = sortInfo;
        }
    }
}
