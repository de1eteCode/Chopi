using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories.Interfaces
{
    public interface IGenericRepository<T, TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> Intersect(IEnumerable<T> collection, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
