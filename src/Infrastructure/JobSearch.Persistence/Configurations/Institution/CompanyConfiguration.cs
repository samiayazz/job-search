using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    private EntityTypeBuilder<Company> _builder;

    public void Configure(EntityTypeBuilder<Company> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Name
        _builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        // Description
        _builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired(false);
    }

    private void ConfigureRelationships()
    {
        // Has One Creator
        _builder.HasOne(company => company.CreatedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById);

        // Has One Sector
        _builder.HasOne(company => company.Sector)
            .WithMany(sector => sector.Companies)
            .HasForeignKey(company => company.SectorId);

        // Has One Address
        _builder.HasOne(company => company.Address)
            .WithOne(address => address.Company)
            .HasForeignKey<Company>(company => company.AddressId);

        // Has Many Jobs
        _builder.HasMany(company => company.Jobs)
            .WithOne(job => job.Company)
            .HasForeignKey(job => job.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        /*// Has One Updater Optional
        _builder.HasOne(company => company.UpdatedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById)
            .IsRequired(false);

        // Has One Remover Optional
        _builder.HasOne(company => company.DeletedBy)
            .WithOne(user => user.Company)
            .HasForeignKey<Company>(company => company.CreatedById)
            .IsRequired(false);*/
    }
}