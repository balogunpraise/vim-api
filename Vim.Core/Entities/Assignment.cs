using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vim.Core.Entities.LinkingEntities;

namespace Vim.Core.Entities
{
    public class Assignment : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<StudentAssignment> Students { get; set; }


        public Assignment()
        {
            Students = new List<StudentAssignment>();
        }
    }
}
