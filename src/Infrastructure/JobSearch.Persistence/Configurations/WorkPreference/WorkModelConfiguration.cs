using JobSearch.Domain.Entities.WorkPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.WorkPreference;

public class WorkModelConfiguration : IEntityTypeConfiguration<WorkModel>
{
    private EntityTypeBuilder<WorkModel> _builder;

    public void Configure(EntityTypeBuilder<WorkModel> builder)
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
        _builder.HasMany(workModel => workModel.Jobs)
            .WithOne(job => job.WorkModel)
            .HasForeignKey(job => job.WorkModelId);
    }
}