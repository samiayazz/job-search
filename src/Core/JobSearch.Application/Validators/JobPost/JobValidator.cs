using FluentValidation;
using JobSearch.Application.Validators.Common;
using JobSearch.Domain.Entities.JobPost;

namespace JobSearch.Application.Validators.JobPost;
public class JobValidator : EntityValidatorBase<Job>
{
    public JobValidator()
    {
        RuleFor(job => job.CreatedBy);
    }
}
