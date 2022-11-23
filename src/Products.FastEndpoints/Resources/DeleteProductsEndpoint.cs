using FastEndpoints;
using ProductsApi.Dto;
using ProductsApi.FastEndpoints.Dto;
using ProductsApi.Services;

namespace ProductsApi.FastEndpoints.Resources
{
    public class DeleteProductsEndpoint : Endpoint<IdRequest, ProductResponse>
    {
        private readonly ProductsService _service;

        public DeleteProductsEndpoint(ProductsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Delete("/products/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(IdRequest request, CancellationToken ct)
        {
            var deleted = await _service.DeleteAsync(request.Id);

            var _ = deleted ? SendNoContentAsync(ct) : SendNotFoundAsync(ct);
            await _;
        }
    }
}
