using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    EntityTypeBuilder<Sector> _builder;

    public void Configure(EntityTypeBuilder<Sector> builder)
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
        // Has Many Companies
        _builder.HasMany(sector => sector.Companies)
            .WithOne(company => company.Sector)
            .HasForeignKey(company => company.SectorId);
    }
}