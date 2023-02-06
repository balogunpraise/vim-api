using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vim.Core.Entities.LinkingEntities;

namespace Vim.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        private bool _isSubscribed;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateSubscribed { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
        public ICollection<StudentAssignment> Assignments { get; set; }
        public bool IsStudent { get; set; } = true;
        public bool IsInstructor { get; set; } = false;
        public bool IsSubscribed 
        { get
            {
                return this._isSubscribed;
            }

          set
            {
                if(DateSubscribed != null && DateSubscribed < ExpirationDate)
                {
                    _isSubscribed = true;
                }
                else
                {
                    _isSubscribed = false;
                }
            }
        }

        public ApplicationUser()
        {
            Courses = new List<StudentCourse>();
            Assignments = new List<StudentAssignment>();
        }

    }
}
