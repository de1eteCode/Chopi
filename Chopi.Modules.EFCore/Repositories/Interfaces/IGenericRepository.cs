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
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
