using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

internal class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    private EntityTypeBuilder<JobApplication> _builder;

    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Description
        _builder.Property(x => x.Description)
            .HasMaxLength(150)
            .IsRequired(false);

        // SalaryExpection
        _builder.Property(x => x.SalaryExpection)
            .HasPrecision(10, 2)
            .HasDefaultValue(0)
            .IsRequired();

        // PeriodOfNotice
        _builder.Property(x => x.PeriodOfNotice)
            .HasDefaultValue(0)
            .IsRequired();
    }

    private void ConfigureRelationships()
    {
        // Has One Job
        _builder.HasOne(app => app.Job)
            .WithMany(job => job.JobApplications)
            .HasForeignKey(app => app.JobId);

        // Has One Applicant
        _builder.HasOne(app => app.Applicant)
            .WithMany(applicant => applicant.JobApplications)
            .HasForeignKey(app => app.ApplicantId);
    }
}