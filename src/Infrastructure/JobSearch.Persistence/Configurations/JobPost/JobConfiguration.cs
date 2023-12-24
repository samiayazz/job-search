using JobSearch.Domain.Entities.JobPost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.JobPost;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    private EntityTypeBuilder<Job> _builder;

    public void Configure(EntityTypeBuilder<Job> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Title
        _builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();

        //Position
        _builder.Property(x => x.Position)
            .HasMaxLength(50)
            .IsRequired();

        // YearsOfExperience
        _builder.Property(x => x.YearsOfExperience)
            .IsRequired();

        // Description
        _builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired();

        // Criteria
        _builder.Property(x => x.Criteria)
            .HasMaxLength(500)
            .IsRequired();
    }

    private void ConfigureRelationships()
    {
        // Has One Creator
        _builder.HasOne(job => job.CreatedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.CreatedById);

        // Has One Company
        _builder.HasOne(job => job.Company)
            .WithMany(company => company.Jobs)
            .HasForeignKey(job => job.CompanyId);

        // Has One Department
        _builder.HasOne(job => job.Department)
            .WithMany(department => department.Jobs)
            .HasForeignKey(job => job.DepartmentId);

        // Has One WorkType
        _builder.HasOne(job => job.WorkType)
            .WithMany(workType => workType.Jobs)
            .HasForeignKey(job => job.WorkTypeId);

        // Has One WorkModel
        _builder.HasOne(job => job.WorkModel)
            .WithMany(workModel => workModel.Jobs)
            .HasForeignKey(job => job.WorkModelId);

        // Has Many JobApplications
        _builder.HasMany(job => job.JobApplications)
            .WithOne(app => app.Job)
            .HasForeignKey(app => app.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        /*// Has One Updater Optional
        _builder.HasOne(job => job.UpdatedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.UpdatedById)
            .IsRequired(false);

        // Has One Remover Optional
        _builder.HasOne(job => job.DeletedBy)
            .WithMany(user => user.Jobs)
            .HasForeignKey(job => job.DeletedById)
            .IsRequired(false);*/
    }
}