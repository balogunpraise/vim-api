using Microsoft.EntityFrameworkCore;
using Vim.Core.Application.Interfaces;
using Vim.Core.Entities;
using Vim.Infrastructure.Data;

namespace Vim.Infrastructure.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialsRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddMaterial(List<Materials> materials)
        {
            try
            {
                await _context.Materials.AddRangeAsync(materials);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        public async Task<Materials> GetMaterialById(string id)
        {
            return await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
