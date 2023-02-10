using Microsoft.Extensions.Logging;
using Vim.Core.Application.IConfigurations;
using Vim.Core.Application.Interfaces;
using Vim.Infrastructure.Repositories;

namespace Vim.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;



        public IStaffRepository Staff { get; private set; }

        public IMaterialsRepository Materials { get; private set; }

        public IStudentRepository Students { get; private set; }


        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            Materials = new MaterialsRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
