using JobSearch.Domain.Entities.Identity;
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

        // Has Many JobApplications
        builder.HasMany(user => user.JobApplications)
            .WithOne(jobApp => jobApp.Applicant)
            .HasForeignKey(jobApplication => jobApplication.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
