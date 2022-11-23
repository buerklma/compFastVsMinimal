using FluentValidation;
using ProductsApi.Dto;

namespace ProductsApi.FastEndpoints.Validation
{
    public class PostProductRequestValidator : AbstractValidator<PostProductRequest>
    {
        public PostProductRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name must be set");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price may not be zero or less");
        }
    }
}
