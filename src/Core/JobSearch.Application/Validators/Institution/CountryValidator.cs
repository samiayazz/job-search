using FluentValidation;
using JobSearch.Domain.Entities.Location;

namespace JobSearch.Application.Validators.Institution;
public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(country => country.Name)
            .NotNull().NotEmpty()
            .WithMessage("The \"Country Name\" field is can't be null or empty!");
    }
}
