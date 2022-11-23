using FastEndpoints;
using FluentValidation;
using ProductsApi.Dto;
using ProductsApi.Services;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.FastEndpoints.Resources
{
    public class PostProductEndpoint : Endpoint<PostProductRequest, ProductResponse>
    {
        private readonly ProductsService _service;

        public PostProductEndpoint(ProductsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Post("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(PostProductRequest request, CancellationToken ct)
        {
            var product = await _service.CreateAsync(request.ToProduct());

            await SendAsync(product.ToProductResponse(), 201, ct);
        }
    }
}
