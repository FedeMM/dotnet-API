using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(X => X.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(X => X.Alcohol).GreaterThan(0).WithMessage(X => "El {PropertyName} mayor a 0");
        }
    }
}
