using FluentValidation;
using ProductsApi.Dto;
using ProductsApi.Services;

namespace ProductsApi.Resources
{
    public static class ProductsResource
    {
        public static void MapProductsResource(this WebApplication app)
        {
            app.MapGet($"/products", async (ProductsService db) =>
            {
                return await HandleGetAll(db);
            });

            app.MapPost($"/products", async (ProductRequest request, ProductsService service, IValidator<ProductRequest> validator) =>
            {
                return await HandlePost(request, service, validator);
            });

            app.MapPut("/products/{id}", async (ProductRequest request, Guid id, ProductsService service, IValidator<ProductRequest> validator) =>
            {
                return await HandlePut(request, id, service, validator);
            });

            app.MapGet("/products/{id}", async (ProductsService service, Guid id) =>
            {
                return await HandleGetOne(service, id);
            });

            app.MapDelete("/products/{id}", async (ProductsService service, Guid id) =>
            {
                return await HandleDelete(service, id);
            });
        }

        private static async Task<IResult> HandleDelete(ProductsService service, Guid id)
        {
            if (id == Guid.Empty)
                return Results.BadRequest($"Parameter {nameof(id)} missing");

            var deleted = await service.DeleteAsync(id);

            return deleted
                ? Results.NoContent()
                : Results.NotFound();
        }

        private static async Task<IResult> HandleGetOne(ProductsService service, Guid id)
        {
            if (id == Guid.Empty)
                return Results.BadRequest($"Parameter {nameof(id)} missing");

            var product = await service.GetAsync(id);

            return product != null
                ? Results.Ok(product.ToProductResponse())
                : Results.NotFound();
        }

        private static async Task<IResult> HandlePut(ProductRequest request, Guid id, ProductsService service, IValidator<ProductRequest> validator)
        {
            if (id == Guid.Empty)
                return Results.BadRequest($"Parameter {nameof(id)} missing");
            var validationResult = await ValidateAsync(validator, request);
            if (!validationResult.IsValid)
                return validationResult.ValidationProblem!;

            var product = await service.UpdateAsync(id, request.ToProduct());

            return product != null
                ? Results.Ok(product.ToProductResponse())
                : Results.NotFound();
        }

        private static async Task<IEnumerable<ProductResponse>> HandleGetAll(ProductsService db)
        {
            var models = await db.GetAllAsync();
            return models.Select(x => x.ToProductResponse());
        }

        private static async Task<IResult> HandlePost(ProductRequest request, ProductsService service, IValidator<ProductRequest> validator)
        {
            var validationResult = await ValidateAsync(validator, request);
            if (!validationResult.IsValid)
                return validationResult.ValidationProblem!;

            var product = await service.CreateAsync(request.ToProduct());
            return Results.Ok(product);
        }

        private static async Task<ValidationResult> ValidateAsync(IValidator<ProductRequest> validator, ProductRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);

            return new ValidationResult
            {
                IsValid = validationResult.IsValid,
                ValidationProblem = validationResult.IsValid ? null : Results.ValidationProblem(validationResult.ToDictionary())
            };
        }
    }
}
