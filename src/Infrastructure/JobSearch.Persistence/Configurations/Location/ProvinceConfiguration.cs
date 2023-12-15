using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    private EntityTypeBuilder<Province> _builder;

    public void Configure(EntityTypeBuilder<Province> builder)
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
        // Has One Country
        _builder.HasOne(province => province.Country)
            .WithMany(country => country.Provinces)
            .HasForeignKey(province => province.CountryId);

        // Has Many Addresses
        _builder.HasMany(province => province.Addresses)
            .WithOne(address => address.Province)
            .HasForeignKey(address => address.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}