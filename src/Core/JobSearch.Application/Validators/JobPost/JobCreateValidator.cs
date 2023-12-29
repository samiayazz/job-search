using FluentValidation;
using JobSearch.Application.DTOs.JobPost;

namespace JobSearch.Application.Validators.JobPost
{
    public class JobCreateValidator : AbstractValidator<JobCreateDto>
    {
        public JobCreateValidator()
        {
            // Title
            RuleFor(x => x.Title)
                .NotNull().WithMessage("'Title' boş geçilemez.")
                .NotEmpty().WithMessage("'Title' boş geçilemez.")
                .MinimumLength(5).WithMessage("'Title' minimum 5 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("'Title' maksimum 50 karakterden oluşmalıdır.");

            // Position
            RuleFor(x => x.Position)
                .NotNull().WithMessage("'Position' boş geçilemez.")
                .NotEmpty().WithMessage("'Position' boş geçilemez.")
                .MinimumLength(5).WithMessage("'Position' minimum 5 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("'Position' maksimum 50 karakterden oluşmalıdır.");

            // YearsOfExperience
            RuleFor(x => x.YearsOfExperience)
                .GreaterThanOrEqualTo((byte)0).WithMessage("'YearsOfExperience' minimum 0 olmalıdır.");

            // Description
            RuleFor(x => x.Description)
                .NotNull().WithMessage("'Description' boş geçilemez.")
                .NotEmpty().WithMessage("'Description' boş geçilemez.")
                .MinimumLength(25).WithMessage("'Description' minimum 25 karakterden oluşmalıdır.")
                .MaximumLength(500).WithMessage("'Description' maksimum 500 karakterden oluşmalıdır.");
            // Criteria
            RuleFor(x => x.Criteria)
                .NotNull().WithMessage("'Criteria' boş geçilemez.")
                .NotEmpty().WithMessage("'Criteria' boş geçilemez.")
                .MinimumLength(25).WithMessage("'Criteria' minimum 25 karakterden oluşmalıdır.")
                .MaximumLength(500).WithMessage("'Criteria' maksimum 500 karakterden oluşmalıdır.");

            // CompanyId
            RuleFor(x => x.CompanyId)
                .NotNull().WithMessage("'CompanyId' boş geçilemez.")
                .NotEmpty().WithMessage("'CompanyId' boş geçilemez.");
            // DepartmentId
            RuleFor(x => x.DepartmentId)
                .NotNull().WithMessage("'DepartmentId' boş geçilemez.")
                .NotEmpty().WithMessage("'DepartmentId' boş geçilemez.");
            // WorkTypeId
            RuleFor(x => x.WorkTypeId)
                .NotNull().WithMessage("'WorkTypeId' boş geçilemez.")
                .NotEmpty().WithMessage("'WorkTypeId' boş geçilemez.");
            // WorkModelId
            RuleFor(x => x.WorkModelId)
                .NotNull().WithMessage("'WorkModelId' boş geçilemez.")
                .NotEmpty().WithMessage("'WorkModelId' boş geçilemez.");
        }
    }
}