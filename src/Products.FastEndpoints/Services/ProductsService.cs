using Microsoft.EntityFrameworkCore;
using ProductsApi.Model;

namespace ProductsApi.Services
{
    public class ProductsService
    {
        private readonly ProductsContext _productsContext;

        public ProductsService(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productsContext.Products.ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            if (product.Id != Guid.Empty)
                throw new InvalidDataException("Id already set. Cannot create product");

            product.Id = Guid.NewGuid();
            await _productsContext.Products.AddAsync(product);
            await _productsContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Guid id, Product product)
        {
            if (id == Guid.Empty)
                throw new InvalidDataException("Product has no id. Cannot update product");
            
            product.Id = id;
            _productsContext.Products.Update(product);
            await _productsContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id));

            return await _productsContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id));

            var product = await GetAsync(id);
            if (product == null)
                return false;

            _productsContext.Products.Remove(product);
            await _productsContext.SaveChangesAsync();

            return true;
        }
    }
}
