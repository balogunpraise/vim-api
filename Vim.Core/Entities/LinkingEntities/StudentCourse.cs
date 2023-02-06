using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vim.Core.Entities.LinkingEntities
{
    public class StudentCourse 
    {
        public string StudentId { get; set; }
        public string CourstId { get; set; }
        public ApplicationUser Student { get; set; }
        public Course Course { get; set; }
    }
}
