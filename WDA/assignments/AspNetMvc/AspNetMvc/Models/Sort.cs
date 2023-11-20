using AspNetMvc.Utilities;
using System.Linq.Expressions;

namespace AspNetMvc.Models
{
    public class Sort<T>
    {
        public required Expression<Func<T, object>> OrderBy { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Asc;
    }
}
