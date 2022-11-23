using FluentValidation;
using ProductsApi.Dto;

namespace ProductsApi.Minimal.Validation
{
    public class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name must be set");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price may not be zero or less");
        }
    }
}
