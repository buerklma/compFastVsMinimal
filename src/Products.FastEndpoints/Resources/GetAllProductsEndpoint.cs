using FastEndpoints;
using ProductsApi.Dto;
using ProductsApi.Services;

namespace ProductsApi.FastEndpoints.Resources
{
    public class GetAllProductsEndpoint : EndpointWithoutRequest<IEnumerable<ProductResponse>>
    {
        private readonly ProductsService _service;

        public GetAllProductsEndpoint(ProductsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var models = await _service.GetAllAsync();
            await SendAsync( models.Select(x => x.ToProductResponse()));
        }
    }
}
