using ProductsApi.Dto;
using ProductsApi.Model;

namespace ProductsApi
{
    public static class MapperExtensions
    {
        public static Product ToProduct(this ProductRequest productRequest)
        {
            return new Product { Name = productRequest.Name, Price = productRequest.Price };
        }

        public static ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse { Id = product.Id, Name = product.Name, Price = product.Price };
        }

    }
}
