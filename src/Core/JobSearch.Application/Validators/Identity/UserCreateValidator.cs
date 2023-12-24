using FluentValidation;
using JobSearch.Application.DTOs.Identity;

namespace JobSearch.Application.Validators.Identity;

public class UserCreateValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateValidator()
    {
        // UserName
        RuleFor(x => x.UserName)
            .NotNull().WithMessage("'UserName' boş geçilemez.")
            .NotEmpty().WithMessage("'UserName' boş geçilemez.")
            .MinimumLength(3).WithMessage("'UserName' minimum 3 karakterden oluşmalıdır.")
            .MaximumLength(50).WithMessage("'UserName' maksimum 50 karakterden oluşmalıdır.");

        // Email
        RuleFor(x => x.Email)
            .NotNull().WithMessage("'Email' boş geçilemez.")
            .NotEmpty().WithMessage("'Email' boş geçilemez.")
            .MinimumLength(5).WithMessage("'Email' minimum 5 karakterden oluşmalıdır.")
            .MaximumLength(254).WithMessage("'Email' maksimum 254 karakterden oluşmalıdır.")
            .EmailAddress().WithMessage("Lütfen geçerli bir 'Email' giriniz.");

        // Password
        RuleFor(x => x.Password)
            .NotNull().WithMessage("'Password' boş geçilemez.")
            .NotEmpty().WithMessage("'Password' boş geçilemez.")
            .MinimumLength(6).WithMessage("'Password' minimum 6 karakterden oluşmalıdır.")
            .MaximumLength(50).WithMessage("'Password' maksimum 50 karakterden oluşmalıdır.");

        // PhoneNumber
        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("'PhoneNumber' boş geçilemez.")
            .NotEmpty().WithMessage("'PhoneNumber' boş geçilemez.")
            .MinimumLength(6).WithMessage("'PhoneNumber' minimum 6 karakterden oluşmalıdır.")
            .MaximumLength(14).WithMessage("'PhoneNumber' maksimum 14 karakterden oluşmalıdır.")
            .Matches(@"^\+(?:[0-9]●?){6,14}[0-9]$").WithMessage("Lütfen geçerli bir 'PhoneNumber' giriniz.");

        // Name
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("'FirstName' boş geçilemez.")
            .NotEmpty().WithMessage("'FirstName' boş geçilemez.")
            .MinimumLength(2).WithMessage("'FirstName' minimum 2 karakterden oluşmalıdır.")
            .MaximumLength(25).WithMessage("'FirstName' maksimum 25 karakterden oluşmalıdır.");
        RuleFor(x => x.LastName)
            .NotNull().WithMessage("'LastName' boş geçilemez.")
            .NotEmpty().WithMessage("'LastName' boş geçilemez.")
            .MinimumLength(2).WithMessage("'LastName' minimum 2 karakterden oluşmalıdır.")
            .MaximumLength(25).WithMessage("'LastName' maksimum 25 karakterden oluşmalıdır.");
    }
}