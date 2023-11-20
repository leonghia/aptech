using AspNetMvc.DatabaseContexts;
using AspNetMvc.Enums;
using AspNetMvc.Extensions;
using AspNetMvc.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNetMvc.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _context;
        private readonly DbSet<T> _table;
        

        public GenericRepository(ShopContext context)
        {
            _context = context;
            _table = _context.Set<T>();     
        }

        public async Task Create(T entityToCreate)
        {
            await _table.AddAsync(entityToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            var entity = await _table.FindAsync(id);
            if (entity is not null)
            {
                _table.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<PagedList<T>> Get(RequestParams? requestParams, Expression<Func<T, bool>>? filter, Expression<Func<T, bool>>? searchPredicate, List<string>? includes, Sort<T>[]? sortPredicates)
        {
            IQueryable<T> query = _table;
            requestParams ??= new RequestParams();
            if (filter is not null)
            {
                query = query.Where<T>(filter);
            }
            if (searchPredicate is not null)
            {
                query = query.Where<T>(searchPredicate);
            }
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (sortPredicates is not null)
            {
                var temp = sortPredicates[0].OrderType == OrderType.Asc ? query.OrderBy<T, object>(sortPredicates[0].OrderBy) : query.OrderByDescending<T, object>(sortPredicates[0].OrderBy);
                if (sortPredicates.Length > 1)
                {
                    for (var i = 0; i < sortPredicates.Length; i++)
                    {
                        temp = sortPredicates[i].OrderType == OrderType.Asc ? temp.ThenBy<T, object>(sortPredicates[i].OrderBy) : temp.ThenByDescending<T, object>(sortPredicates[i].OrderBy);
                    }
                }
                query = temp;
            }          
            return await query.ToPagedListAsync<T>(requestParams.PageSize, requestParams.PageNumber);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate, List<string>? includes)
        {
            IQueryable<T> query = _table;
            query = query.Where<T>(predicate);
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include<T>(include);
                }
            }
            var entity = await query.FirstOrDefaultAsync<T>();
            return entity;
        }

        public async Task Update(T entityToUpdate)
        {
            _table.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
