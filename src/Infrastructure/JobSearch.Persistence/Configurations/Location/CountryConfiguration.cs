using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        private EntityTypeBuilder<Country> _builder;

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            _builder = builder;

            ConfigureRelationships();

            // Name
            _builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            SeedData();
        }

        private void ConfigureRelationships()
        {
            // Has Many Provinces
            _builder.HasMany(country => country.Provinces)
                .WithOne(province => province.Country)
                .HasForeignKey(province => province.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SeedData()
        {
            _builder.HasData(new Country
            {
                Id = Guid.Parse("FBAA76DA-0F6B-46C7-930F-586E3BBA2CF8"),
                Name = "Türkiye"
            });
        }
    }
}