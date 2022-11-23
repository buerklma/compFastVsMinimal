using FluentValidation;
using ProductsApi.Dto;

namespace ProductsApi.FastEndpoints.Validation
{
    public class PutProductRequestValidator : AbstractValidator<PutProductRequest>
    {
        public PutProductRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name must be set");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price may not be zero or less");
        }
    }
}
