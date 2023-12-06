using ExamWeb.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ExamWeb.Extensions
{
    public static class QueryExtensions
    {
        public static async Task<PagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> query, int pageSize, int pageNumber)
        {
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return new PagedList<TEntity>(items, totalCount, pageSize, pageNumber);
        }
    }
}
