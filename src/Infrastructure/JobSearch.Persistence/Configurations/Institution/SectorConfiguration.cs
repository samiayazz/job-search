using JobSearch.Domain.Entities.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Institution
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        private EntityTypeBuilder<Sector> _builder;

        public void Configure(EntityTypeBuilder<Sector> builder)
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
            // Has Many Companies
            _builder.HasMany(sector => sector.Companies)
                .WithOne(company => company.Sector)
                .HasForeignKey(company => company.SectorId);
        }

        private void SeedData()
        {
            _builder.HasData(new List<Sector>
            {
                new()
                {
                    Id = Guid.Parse("F4901614-5E4F-4B47-B72B-7A21585263EB"),
                    Name = "Information Technologies"
                }
            });
        }
    }
}