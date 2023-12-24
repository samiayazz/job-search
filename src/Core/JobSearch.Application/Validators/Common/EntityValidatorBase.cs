using FluentValidation;
using JobSearch.Application.Contracts.Domain;
using JobSearch.Domain.Entities.Common;

namespace JobSearch.Application.Validators.Common;

public abstract class EntityValidatorBase<T> : AbstractValidator<T> where T : ModifiableEntityBase
{
    public EntityValidatorBase()
    {
    }
}