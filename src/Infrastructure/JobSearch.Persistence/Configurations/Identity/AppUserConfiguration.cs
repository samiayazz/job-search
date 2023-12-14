using JobSearch.Domain.Entities.Identity;
using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Identity;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);

        // Has One Role
        builder.HasOne(user => user.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(user => user.RoleId);

        // Has Many Addresses
        builder.HasMany(user => user.Addresses)
            .WithOne(address => address.CreatedBy)
            .HasForeignKey(address => address.CreatedById)
            .OnDelete(DeleteBehavior.Cascade); // The addresses will delete when user deleted.

        /*// Has Many Addresses Updater Optional
        builder.HasMany(user => user.Addresses)
            .WithOne(address => address.UpdatedBy)
            .HasForeignKey(address => address.UpdatedById)
            .IsRequired(false);

        // Has Many Addresses Remover Optional
        builder.HasMany(user => user.Addresses)
            .WithOne(address => address.DeletedBy)
            .HasForeignKey(address => address.DeletedById)
            .IsRequired(false);*/

        // Has Many JobApplications
        builder.HasMany(user => user.JobApplications)
            .WithOne(jobApp => jobApp.Applicant)
            .HasForeignKey(jobApplication => jobApplication.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Has Many Jobs Creator Optional
        builder.HasMany(user => user.Jobs)
            .WithOne(job => job.CreatedBy)
            .HasForeignKey(job => job.CreatedById)
            .IsRequired(false);

        /*// Has Many Jobs Updater Optional
        builder.HasMany(user => user.Jobs)
            .WithOne(job => job.UpdatedBy)
            .HasForeignKey(job => job.UpdatedById)
            .IsRequired(false);

        // Has Many Jobs Remover Optional
        builder.HasMany(user => user.Jobs)
            .WithOne(job => job.DeletedBy)
            .HasForeignKey(job => job.DeletedById)
            .IsRequired(false);*/

        // Has One Company Creator Optional
        builder.HasOne(user => user.Company)
            .WithOne(company => company.CreatedBy)
            .HasForeignKey<AppUser>(user => user.CompanyId)
            .IsRequired(false);

        /*// Has One Company Updater Optional
        builder.HasOne(user => user.Company)
            .WithOne(company => company.UpdatedBy)
            .HasForeignKey<AppUser>(user => user.CompanyId)
            .IsRequired(false);

        // Has One Company Remover Optional
        builder.HasOne(user => user.Company)
            .WithOne(company => company.DeletedBy)
            .HasForeignKey<AppUser>(user => user.CompanyId)
            .IsRequired(false);*/
    }
}
