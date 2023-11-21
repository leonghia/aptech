using AspNetMvc.DatabaseContexts;
using AspNetMvc.Enums;
using AspNetMvc.Extensions;
using AspNetMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNetMvc.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _context;
        private readonly DbSet<T> _dbSet;
        

        public GenericRepository(ShopContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();     
        }

        public void Create(T entityToCreate)
        {
            _dbSet.Add(entityToCreate);           
        }

        public void Delete(T entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public async Task<PagedList<T>> Get(RequestParams? requestParams, Expression<Func<T, bool>>? filter, Expression<Func<T, bool>>? searchPredicate, List<string>? includes, Sort<T>[]? sortPredicates)
        {
            IQueryable<T> query = _dbSet;
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
            IQueryable<T> query = _dbSet;
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

        public void Update(T entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);         
        }

        public async Task<T?> FindById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
