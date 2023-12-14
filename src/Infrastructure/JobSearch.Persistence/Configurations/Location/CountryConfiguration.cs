using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Has Many Provinces
        builder.HasMany(country => country.Provinces)
            .WithOne(province => province.Country)
            .HasForeignKey(province => province.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
