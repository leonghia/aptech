using AspNetMvc.Entities;
using AspNetMvc.Models;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AspNetMvc.Utilities
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageSize, int pageNumber)
        {
            var count = await query.CountAsync<T>();
            var items = await query
                .Skip<T>(pageSize * (pageNumber - 1))
                .Take<T>(pageSize)
                .ToListAsync<T>();
            return new PagedList<T>(items, count, pageSize, pageNumber);
        }    

        
    }
}
