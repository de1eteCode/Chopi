using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Chopi.Modules.EFCore.Repositories.Interfaces
{
    public interface IGenericRepository<T, TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {
        T GetById(TKey id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        public IEnumerable<TResult> SelectMany<TResult>(Expression<Func<T, IEnumerable<TResult>>> selector)
           where TResult : class;
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
