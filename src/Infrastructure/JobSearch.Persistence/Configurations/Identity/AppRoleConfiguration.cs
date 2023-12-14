using JobSearch.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Identity;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        // Has Many Users
        builder.HasMany(role => role.Users)
            .WithOne(user => user.Role)
            .HasForeignKey(user => user.RoleId);
    }
}
