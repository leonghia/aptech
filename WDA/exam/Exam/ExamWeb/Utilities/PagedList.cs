namespace ExamWeb.Utilities
{
    public class PagedList<TEntity> : List<TEntity>
    {

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public PagedList(List<TEntity> items, int totalCount, int pageSize, int pageNumber) : base(items)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        }
    }
}
