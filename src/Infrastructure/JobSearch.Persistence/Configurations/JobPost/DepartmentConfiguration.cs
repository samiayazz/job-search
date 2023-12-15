using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    private EntityTypeBuilder<Department> _builder;

    public void Configure(EntityTypeBuilder<Department> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Name
        _builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }

    private void ConfigureRelationships()
    {
        // Has Many Jobs
        _builder.HasMany(department => department.Jobs)
            .WithOne(job => job.Department)
            .HasForeignKey(job => job.DepartmentId);
    }
}