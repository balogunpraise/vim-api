using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vim.Core.Application.Interfaces;
using Vim.Infrastructure.Data;

namespace Vim.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        protected readonly ILogger _logget;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logget = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
