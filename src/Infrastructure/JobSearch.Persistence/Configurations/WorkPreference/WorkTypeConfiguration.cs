using JobSearch.Domain.Entities.WorkPreference;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.WorkPreference
{
    public class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
    {
        private EntityTypeBuilder<WorkType> _builder;

        public void Configure(EntityTypeBuilder<WorkType> builder)
        {
            _builder = builder;

            ConfigureRelationships();

            // Name
            _builder.Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();

            SeedData();
        }

        private void ConfigureRelationships()
        {
            // Has Many Jobs
            _builder.HasMany(workType => workType.Jobs)
                .WithOne(job => job.WorkType)
                .HasForeignKey(job => job.WorkTypeId);
        }

        private void SeedData()
        {
            _builder.HasData(new List<WorkType>
            {
                new()
                {
                    Id = Guid.Parse("00B46EDD-6FC4-4999-A141-A01D95D82EE3"),
                    Name = "Full-time"
                },
                new()
                {
                    Id = Guid.Parse("EB124238-70CF-41F6-B5A2-F515C25515F2"),
                    Name = "Part-time"
                },
                new()
                {
                    Id = Guid.Parse("D68427A8-96BB-4590-BF6F-29ABBE47733F"),
                    Name = "Project-basis"
                },
                new()
                {
                    Id = Guid.Parse("6116ED65-8DA7-4820-9A92-8BD89CAF03AB"),
                    Name = "Intern"
                },
                new()
                {
                    Id = Guid.Parse("E6D8E023-8061-455A-98C1-ED8CCDE1DB3F"),
                    Name = "Freelance"
                }
            });
        }
    }
}