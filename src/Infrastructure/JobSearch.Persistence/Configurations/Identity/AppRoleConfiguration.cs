using JobSearch.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Identity;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    private EntityTypeBuilder<AppRole> _builder;

    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        _builder = builder;

        // Has Many Users
        _builder.HasMany(role => role.Users)
            .WithOne(user => user.Role)
            .HasForeignKey(user => user.RoleId);

        SeedData();
    }

    private void SeedData()
    {
        _builder.HasData(new List<AppRole>()
        {
            new()
            {
                Id = Guid.Parse("28EAE083-2A81-46D2-8F61-3CAEF8DA407C"),
                Name = "Founder"
            },
            new()
            {
                Id = Guid.Parse("E119C4FB-5BA5-4BD4-83C3-CB8EC2D72688"),
                Name = "Recruiter"
            },
            new()
            {
                Id = Guid.Parse("9D913087-D36D-4A5C-AB9D-E9D7845D48E2"),
                Name = "Worker"
            }
        });
    }
}