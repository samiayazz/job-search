using JobSearch.Domain.Entities.WorkPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.WorkPreference;

public class WorkModelConfiguration : IEntityTypeConfiguration<WorkModel>
{
    public void Configure(EntityTypeBuilder<WorkModel> builder)
    {
        // Has Many Jobs
        builder.HasMany(workModel => workModel.Jobs)
            .WithOne(job => job.WorkModel)
            .HasForeignKey(job => job.WorkModelId);
    }
}
