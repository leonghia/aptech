namespace AspNetMvc.Models
{
    public class PagedList<T> : List<T>
    {
        public new int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public PagedList(List<T> items, int count, int pageSize, int pageNumber)
        {        
            Count = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling((double)Count / PageSize);
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;
            AddRange(items);
        }
    }
}
