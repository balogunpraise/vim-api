using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vim.Core.Application.Interfaces;

namespace Vim.Core.Application.IConfigurations
{
    public interface IUnitOfWork
    {
        IStaffRepository Staff { get; }
        IMaterialsRepository Materials { get; }
        IStudentRepository Students { get; }

        Task CompleteAsync();
    }
}
