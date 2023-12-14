using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        // Has One Country
        builder.HasOne(province => province.Country)
            .WithMany(country => country.Provinces)
            .HasForeignKey(province => province.CountryId);

        // Has Many Addresses
        builder.HasMany(province => province.Addresses)
            .WithOne(address => address.Province)
            .HasForeignKey(address => address.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
