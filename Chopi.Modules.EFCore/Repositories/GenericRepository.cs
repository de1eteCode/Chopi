using Chopi.Modules.EFCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T, Guid>
        where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            Include(ref query, ref include);
            return query;
        }

        public async Task Remove(T entity)
        {
            var e = await _db.FindAsync(entity);
            _db.Remove(e);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            Include(ref query, ref include);
            return query.Where(predicate);
        }

        private static void Include(ref IQueryable<T> query, ref Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            if (include is not null)
            {
                include(query);
            }
        }
    }
}
