using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolMgt.Data;
using SchoolMgt.Models;
using SchoolMgt.Repository;

namespace SchoolMgt;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly DbSet<T> _table;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    public void Add(T entity)
    {
        _table.Add(entity);
    }

    public void Delete(int id)
    {
        var result = _table.Find(id);
        _table.Remove(result);
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, List<string> includes = null)
    {
        IQueryable<T> query = _table;
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetSingle(int id)
    {
        var result = await _table.FindAsync(id);
        return result;
    }

    public void Update(T entity)
    {
        _table.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
