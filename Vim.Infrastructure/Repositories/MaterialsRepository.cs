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

        public override async Task<IEnumerable<Materials>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All mettod error", typeof(MaterialsRepository));
                return new List<Materials>();
            }
        }

        public override async Task<bool> Upsert(Materials entity)
        {
           
            try
            {
                var existingMaterial = await dbSet.Where(x => x.Id == entity.Id)
               .FirstOrDefaultAsync();
                if (existingMaterial == null)
                    return await AddAsync(entity);
                existingMaterial.MaterialName = entity.MaterialName;
                existingMaterial.Url = entity.Url;
                existingMaterial.PictureUrl = entity.PictureUrl;
                existingMaterial.UpdatedAt = DateTime.UtcNow;
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(MaterialsRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(string id)
        {
            try
            {
                var existingMaterial = await dbSet.Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                if(existingMaterial != null)
                {
                    dbSet.Remove(existingMaterial);
                }
                return false;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(MaterialsRepository));
                return false;
            }
        }
    }
}
