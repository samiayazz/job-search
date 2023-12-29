using JobSearch.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Common
{
    public class ModifiableEntityBaseConfiguration : IEntityTypeConfiguration<ModifiableEntityBase>
    {
        public void Configure(EntityTypeBuilder<ModifiableEntityBase> builder)
        {
            // CreatedDate
            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            // CreatedBy
            builder.Property(x => x.CreatedById)
                .IsRequired();

            // Todo: Add an interceptor for auto setting 'CreatedBy and CreatedById' props.
        }
    }
}