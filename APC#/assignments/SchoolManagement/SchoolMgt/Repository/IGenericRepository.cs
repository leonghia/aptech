using System.Linq.Expressions;
using SchoolMgt.Models;

namespace SchoolMgt.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, List<string> includes = null);
    Task<T> GetSingle(int id);
    void Add(T entity);
    void Delete(int id);
    void Update(T entity);
}
