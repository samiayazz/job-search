using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Has One Province
        builder.HasOne(address => address.Province)
            .WithMany(province => province.Addresses)
            .HasForeignKey(address => address.ProvinceId);

        // Has One Company Optional
        builder.HasOne(address => address.Company)
            .WithOne(company => company.Address)
            .HasForeignKey<Address>(address => address.CompanyId)
            .IsRequired(false);
    }
}
