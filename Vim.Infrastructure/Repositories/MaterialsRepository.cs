using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vim.Core.Application.Interfaces;
using Vim.Core.Entities;
using Vim.Infrastructure.Data;

namespace Vim.Infrastructure.Repositories
{
    public class MaterialsRepository : GenericRepository<Materials>,  IMaterialsRepository
    {

        public MaterialsRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }


    }
}
