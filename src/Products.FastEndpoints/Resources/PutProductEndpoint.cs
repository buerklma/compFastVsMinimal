using FastEndpoints;
using ProductsApi.Dto;
using ProductsApi.Services;

namespace ProductsApi.FastEndpoints.Resources
{
    public class PutProductEndpoint : Endpoint<PutProductRequest, ProductResponse>
    {
        private readonly ProductsService _service;
        public PutProductEndpoint(ProductsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Put("/products/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(PutProductRequest request, CancellationToken ct)
        {
            var product = await _service.UpdateAsync(request.Id, request.ToProduct());

            await SendAsync(product.ToProductResponse(), 201, ct);
        }
    }
}
