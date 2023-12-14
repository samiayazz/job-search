using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        // Has Many Companies
        builder.HasMany(sector => sector.Companies)
            .WithOne(company => company.Sector)
            .HasForeignKey(company => company.SectorId);
    }
}
