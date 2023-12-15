using FluentValidation;
using JobSearch.Application.Validators.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Validators.JobPost;
public class CreateJobValidator : EntityValidatorBase<Job>
{
    public CreateJobValidator()
    {
        RuleFor(job => job.CreatedBy);
    }
}
