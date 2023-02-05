using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vim.Core.Application.Enums;

namespace Vim.Core.Entities
{
    public class Course : BaseEntity
    {
        public CouseName CoursName { get; set; }
        public decimal Amount { get; set; }
        public bool? IsMajor { get; set; }
    }
}
