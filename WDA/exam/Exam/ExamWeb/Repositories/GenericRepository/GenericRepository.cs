using ExamWeb.Extensions;
using ExamWeb.DatabaseContexts;
using ExamWeb.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamonimyWeb.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ExamContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ExamContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, List<string>? includedProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where<TEntity>(filter);          

            if (includedProperties is not null)
            {
                foreach (var includedProperty in includedProperties) 
                {
                    query = query.Include<TEntity>(includedProperty);
                }
            }

            return await query.FirstOrDefaultAsync<TEntity>();

        }       

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<PagedList<TEntity>> GetAsync(RequestParams? requestParams, Expression<Func<TEntity, bool>>? filter, List<string>? includedProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter is not null)
            {
                query = query.Where<TEntity>(filter);
            }

            if (includedProperties is not null)
            {
                foreach (var includedProperty in includedProperties)
                {
                    query = query.Include(includedProperty);
                }
            }

            requestParams ??= new RequestParams();

            return await query.ToPagedListAsync(requestParams.PageSize, requestParams.PageNumber);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
