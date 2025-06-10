using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator() {
            RuleFor(X => X.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(X => X.Alcohol).GreaterThan(0).WithMessage(X => "El {PropertyName} mayor a 0");
        }
    }
}
