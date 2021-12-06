using Chopi.Modules.EFCore.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories
{
    public abstract class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly AppDbContext _context;

        protected UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
