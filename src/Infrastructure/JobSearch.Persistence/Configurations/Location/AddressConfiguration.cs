using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Has One Creator
        builder.HasOne(address => address.CreatedBy)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.CreatedById);

        // Has One Province
        builder.HasOne(address => address.Province)
            .WithMany(province => province.Addresses)
            .HasForeignKey(address => address.ProvinceId);

        // Has One AppUser
        builder.HasOne(address => address.CreatedBy)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.CreatedById);

        // Has One Company Optional
        builder.HasOne(address => address.Company)
            .WithOne(company => company.Address)
            .HasForeignKey<Address>(address => address.CompanyId)
            .IsRequired(false);

        /*// Has One Updater Optional
        builder.HasOne(address => address.UpdatedBy)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.UpdatedById)
            .IsRequired(false);

        // Has One Remover Optional
        builder.HasOne(address => address.DeletedBy)
            .WithMany(user => user.Addresses)
            .HasForeignKey(address => address.DeletedById)
            .IsRequired(false);*/
    }
}
