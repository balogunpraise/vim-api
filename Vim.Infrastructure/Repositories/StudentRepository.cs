using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vim.Core.Application.Interfaces;
using Vim.Core.Entities;

namespace Vim.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task<bool> AddAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
