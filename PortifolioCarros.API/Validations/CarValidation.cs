using FluentValidation;
using PortifolioCarros.API.Entities;

namespace PortifolioCarros.API.Validations
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(500);

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .When(x => x is not null);

            RuleFor(x => x.Pictures)
                .Must(x => x.Count > 0);

            RuleFor(x => x.Brand)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Year)
                .Must(x => x > 1800);

            RuleFor(x => x.Price)
                .Must(x => x > 0);

            RuleFor(x => x.TechnicalDescription)
                .MaximumLength(5000)
                .When(x => x is not null);
        }
    }
}
