using JobSearch.Domain.Entities.WorkPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.WorkPreference;

public class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
{
    private EntityTypeBuilder<WorkType> _builder;

    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Name
        _builder.Property(x => x.Name)
            .HasMaxLength(25)
            .IsRequired();
    }

    private void ConfigureRelationships()
    {
        // Has Many Jobs
        _builder.HasMany(workType => workType.Jobs)
            .WithOne(job => job.WorkType)
            .HasForeignKey(job => job.WorkTypeId);
    }
}