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

        SeedData();
    }

    private void ConfigureRelationships()
    {
        // Has Many Jobs
        _builder.HasMany(department => department.Jobs)
            .WithOne(job => job.Department)
            .HasForeignKey(job => job.DepartmentId);
    }

    private void SeedData()
    {
        _builder.HasData(new List<Department>()
        {
            new()
            {
                Id = Guid.Parse("8AAF619E-E69E-4178-B5E0-04344D04B429"),
                Name = "Software Development"
            }
        });
    }
}