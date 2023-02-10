using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vim.Core.Application.Interfaces;
using Vim.Infrastructure.Data;

namespace Vim.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        protected readonly ILogger _logger;
    
        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

    }
}
