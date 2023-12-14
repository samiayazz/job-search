using JobSearch.Domain.Entities.Institution;
using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        // Has One Creator
        builder.HasOne(job => job.CreatedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.CreatedById);

        // Has One Company
        builder.HasOne(job => job.Company)
            .WithMany(company => company.Jobs)
            .HasForeignKey(job => job.CompanyId);

        // Has One Department
        builder.HasOne(job => job.Department)
            .WithMany(department => department.Jobs)
            .HasForeignKey(job => job.DepartmentId);

        // Has One WorkType
        builder.HasOne(job => job.WorkType)
            .WithMany(workType => workType.Jobs)
            .HasForeignKey(job => job.WorkTypeId);

        // Has One WorkModel
        builder.HasOne(job => job.WorkModel)
            .WithMany(workModel => workModel.Jobs)
            .HasForeignKey(job => job.WorkModelId);

        // Has Many JobApplications
        builder.HasMany(job => job.JobApplications)
            .WithOne(app => app.Job)
            .HasForeignKey(app => app.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        /*// Has One Updater Optional
        builder.HasOne(job => job.UpdatedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.UpdatedById)
            .IsRequired(false);

        // Has One Remover Optional
        builder.HasOne(job => job.DeletedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.DeletedById)
            .IsRequired(false);*/
    }
}
