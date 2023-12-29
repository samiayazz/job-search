using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        private EntityTypeBuilder<Address> _builder;

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            _builder = builder;

            ConfigureRelationships();

            // Title
            _builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            // District
            _builder.Property(x => x.District)
                .HasMaxLength(50)
                .IsRequired();

            // Neighborhood
            _builder.Property(x => x.Neighborhood)
                .HasMaxLength(50)
                .IsRequired(false);

            // FullAddress
            _builder.Property(x => x.FullAddress)
                .HasMaxLength(150)
                .IsRequired(false);
        }

        private void ConfigureRelationships()
        {
            // Has One Creator
            _builder.HasOne(address => address.CreatedBy)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.CreatedById);

            // Has One Province
            _builder.HasOne(address => address.Province)
                .WithMany(province => province.Addresses)
                .HasForeignKey(address => address.ProvinceId);

            // Has One AppUser
            _builder.HasOne(address => address.CreatedBy)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.CreatedById);

            // Has One Company Optional
            _builder.HasOne(address => address.Company)
                .WithOne(company => company.Address)
                .HasForeignKey<Address>(address => address.CompanyId)
                .IsRequired(false);

            /*// Has One Updater Optional
            _builder.HasOne(address => address.UpdatedBy)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.UpdatedById)
                .IsRequired(false);

            // Has One Remover Optional
            _builder.HasOne(address => address.DeletedBy)
                .WithMany(user => user.Addresses)
                .HasForeignKey(address => address.DeletedById)
                .IsRequired(false);*/
        }
    }
}