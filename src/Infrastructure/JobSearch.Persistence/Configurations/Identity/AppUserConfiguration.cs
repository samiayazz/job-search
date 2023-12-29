using JobSearch.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private EntityTypeBuilder<AppUser> _builder;

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            _builder = builder;

            ConfigureRelationships();

            // FirstName
            _builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            // LastName
            _builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            // UserName
            _builder.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            // Email
            _builder.Property(x => x.Email)
                .HasMaxLength(254)
                .IsRequired();

            // EmailConfirmed
            _builder.Property(x => x.EmailConfirmed)
                .HasDefaultValue(0)
                .IsRequired();

            // PasswordHash
            _builder.Property(x => x.PasswordHash)
                .IsRequired();

            // PhoneNumber
            _builder.Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            // PhoneNumberConfirmed
            _builder.Property(x => x.PhoneNumberConfirmed)
                .HasDefaultValue(0)
                .IsRequired();
        }

        private void ConfigureRelationships()
        {
            // Has One Role
            _builder.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId);

            // Has Many Addresses
            _builder.HasMany(user => user.Addresses)
                .WithOne(address => address.CreatedBy)
                .HasForeignKey(address => address.CreatedById)
                .OnDelete(DeleteBehavior.Cascade); // The addresses will delete when user deleted.

            /*// Has Many Addresses Updater Optional
            _builder.HasMany(user => user.Addresses)
                .WithOne(address => address.UpdatedBy)
                .HasForeignKey(address => address.UpdatedById)
                .IsRequired(false);

            // Has Many Addresses Remover Optional
            _builder.HasMany(user => user.Addresses)
                .WithOne(address => address.DeletedBy)
                .HasForeignKey(address => address.DeletedById)
                .IsRequired(false);*/

            // Has Many JobApplications
            _builder.HasMany(user => user.JobApplications)
                .WithOne(jobApp => jobApp.Applicant)
                .HasForeignKey(jobApplication => jobApplication.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Has Many Jobs Creator Optional
            _builder.HasMany(user => user.Jobs)
                .WithOne(job => job.CreatedBy)
                .HasForeignKey(job => job.CreatedById)
                .IsRequired(false);

            /*// Has Many Jobs Updater Optional
            _builder.HasMany(user => user.Jobs)
                .WithOne(job => job.UpdatedBy)
                .HasForeignKey(job => job.UpdatedById)
                .IsRequired(false);

            // Has Many Jobs Remover Optional
            _builder.HasMany(user => user.Jobs)
                .WithOne(job => job.DeletedBy)
                .HasForeignKey(job => job.DeletedById)
                .IsRequired(false);*/

            // Has One Company Creator Optional
            _builder.HasOne(user => user.Company)
                .WithOne(company => company.CreatedBy)
                .HasForeignKey<AppUser>(user => user.CompanyId)
                .IsRequired(false);

            /*// Has One Company Updater Optional
            _builder.HasOne(user => user.Company)
                .WithOne(company => company.UpdatedBy)
                .HasForeignKey<AppUser>(user => user.CompanyId)
                .IsRequired(false);

            // Has One Company Remover Optional
            _builder.HasOne(user => user.Company)
                .WithOne(company => company.DeletedBy)
                .HasForeignKey<AppUser>(user => user.CompanyId)
                .IsRequired(false);*/
        }
    }
}