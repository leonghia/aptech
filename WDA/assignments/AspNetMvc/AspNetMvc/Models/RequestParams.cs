using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace AspNetMvc.Models
{
    public class RequestParams
    {
        public string? SearchQuery { get; set; }
        public string? OrderBy { get; set; }
        public string? Fields { get; set; }

        private const int _maxPageSize = 20;
        [Range(0, _maxPageSize)] 
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
        }

        [Range(0, int.MaxValue)]     
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        
    }
}
