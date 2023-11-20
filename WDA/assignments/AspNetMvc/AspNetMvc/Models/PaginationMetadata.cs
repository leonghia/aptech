namespace AspNetMvc.Models
{
    public class PaginationMetadata
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }     
    }
}
