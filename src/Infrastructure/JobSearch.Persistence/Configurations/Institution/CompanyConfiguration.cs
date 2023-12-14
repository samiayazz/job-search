using JobSearch.Domain.Entities.Identity;
using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        // Has One Creator
        builder.HasOne(company => company.CreatedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById);

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

        /*// Has One Updater Optional
        builder.HasOne(company => company.UpdatedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById)
            .IsRequired(false);

        // Has One Remover Optional
        builder.HasOne(company => company.DeletedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById)
            .IsRequired(false);*/
    }
}
