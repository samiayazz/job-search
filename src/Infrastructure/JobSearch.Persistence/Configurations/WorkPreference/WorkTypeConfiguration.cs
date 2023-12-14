using JobSearch.Domain.Entities.WorkPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.WorkPreference;

public class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
{
    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        // Has Many Jobs
        builder.HasMany(workType => workType.Jobs)
            .WithOne(job => job.WorkType)
            .HasForeignKey(job => job.WorkTypeId);
    }
}
