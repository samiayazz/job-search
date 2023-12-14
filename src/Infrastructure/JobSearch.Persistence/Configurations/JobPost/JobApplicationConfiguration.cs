using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

internal class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        // Has One Job
        builder.HasOne(app => app.Job)
            .WithMany(job => job.JobApplications)
            .HasForeignKey(app => app.JobId);

        // Has One Applicant
        builder.HasOne(app => app.Applicant)
            .WithMany(applicant => applicant.JobApplications)
            .HasForeignKey(app => app.ApplicantId);
    }
}
