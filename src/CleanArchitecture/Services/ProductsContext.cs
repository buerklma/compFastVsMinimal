using Microsoft.EntityFrameworkCore;
using ProductsApi.Model;

namespace ProductsApi.Services
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
