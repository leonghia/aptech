using AspNetMvc.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;

namespace AspNetMvc.Repositories.GenericRepository
{
    public interface IGenericRepository<T>
    {
        Task<PagedList<T>> Get(RequestParams? requestParams, Expression<Func<T, bool>>? filter, Expression<Func<T, bool>>? searchPredicate, List<string>? includes, Sort<T>[]? sortPredicates);
        Task<T?> Get(Expression<Func<T, bool>> predicate, List<string>? includes);
        void Create(T entityToCreate);
        void Update(T entityToUpdate);
        void Delete(T entityToDelete);
        Task<T?> FindById(object id);
        Task SaveAsync();
    }
}
