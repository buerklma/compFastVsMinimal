using FluentValidation;
using ProductsApi.FastEndpoints.Dto;

namespace ProductsApi.FastEndpoints.Validation
{
    public class IdValidator : AbstractValidator<IdRequest>
    {
        public IdValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
