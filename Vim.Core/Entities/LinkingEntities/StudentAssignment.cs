using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vim.Core.Entities.LinkingEntities
{
    public class StudentAssignment
    {
        public string AssignmentId { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
