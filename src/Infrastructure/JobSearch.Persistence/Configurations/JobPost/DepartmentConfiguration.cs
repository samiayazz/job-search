using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Has Many Jobs
        builder.HasMany(department => department.Jobs)
            .WithOne(job => job.Department)
            .HasForeignKey(job => job.DepartmentId);
    }
}
