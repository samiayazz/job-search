using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        // Has One Sector
        builder.HasOne(company => company.Sector)
            .WithMany(sector => sector.Companies)
            .HasForeignKey(company => company.SectorId);

        // Has One Address
        builder.HasOne(company => company.Address)
            .WithOne(address => address.Company)
            .HasForeignKey<Company>(company => company.AddressId);

        // Has Many Jobs
        builder.HasMany(company => company.Jobs)
            .WithOne(job => job.Company)
            .HasForeignKey(job => job.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
