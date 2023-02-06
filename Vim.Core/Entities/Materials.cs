using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vim.Core.Entities
{
    public class Materials : BaseEntity
    {
        public string MaterialName { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string Url { get; set; }
    }
}
