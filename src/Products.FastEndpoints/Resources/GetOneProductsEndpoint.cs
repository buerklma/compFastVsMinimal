using FastEndpoints;
using ProductsApi.Dto;
using ProductsApi.FastEndpoints.Dto;
using ProductsApi.Services;

namespace ProductsApi.FastEndpoints.Resources
{
    public class GetOneProductsEndpoint : Endpoint<IdRequest, ProductResponse>
    {
        private readonly ProductsService _service;

        public GetOneProductsEndpoint(ProductsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("/products/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(IdRequest request, CancellationToken ct)
        {
            var model = await _service.GetAsync(request.Id);
            if (model == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendAsync(model.ToProductResponse());
        }
    }
}
