using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vim.Core.Entities.LinkingEntities;

namespace Vim.Infrastructure.Configurations
{
    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.AssignmentId });
        }
    }
}
