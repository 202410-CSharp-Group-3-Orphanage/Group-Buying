namespace Forestage.Models.Infra
{
    public class PaginationInfo
    {
        public PaginationInfo(int totalCount, int pageSize, int pageNumber)
        {
            TotalCount = totalCount < 0 ? 0 : totalCount;
            PageSize = pageSize < 1 ? 1 : pageSize;
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
        }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public int Pages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public int PageItemCount => 5;

        public int PageBarStartNumber
        {
            get
            {
                int startNumber = PageNumber - (int)Math.Floor((double)PageItemCount / 2);
                return startNumber < 1 ? 1 : startNumber;
            }
        }
        public IEnumerable<T> GetPagedData<T>(IEnumerable<T> query)
        {
            int recordStartIndex = (PageNumber - 1) * PageSize;

            return query.Skip(recordStartIndex).Take(PageSize);
        }

        public int PageBarItemCount => PageBarStartNumber + PageItemCount > Pages
            ? Pages - PageBarStartNumber + 1
            : PageItemCount;

        public int PageItemNextNumber => PageBarStartNumber + PageItemCount >= Pages ? Pages : PageBarStartNumber + PageItemCount;
        public int PageItemPrevNumber => PageBarStartNumber <= 1 ? 1 : PageBarStartNumber - 1;

    }
}
