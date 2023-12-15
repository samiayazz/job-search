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

        SeedData();
    }

    private void ConfigureRelationships()
    {
        // Has Many Jobs
        _builder.HasMany(workModel => workModel.Jobs)
            .WithOne(job => job.WorkModel)
            .HasForeignKey(job => job.WorkModelId);
    }

    private void SeedData()
    {
        _builder.HasData(new List<WorkModel>()
        {
            new()
            {
                Id = Guid.Parse("BE2D4821-3C84-4552-B292-6305887B8FED"),
                Name = "In-office"
            },
            new()
            {
                Id = Guid.Parse("5CFDD002-0E17-4F85-9785-AF001251C568"),
                Name = "Hybrid"
            },
            new()
            {
                Id = Guid.Parse("4CFA49E2-005A-45EB-A87D-63A35AA4A1B0"),
                Name = "Remote"
            }
        });
    }
}