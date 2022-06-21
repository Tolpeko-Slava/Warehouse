using Microsoft.EntityFrameworkCore;

namespace Warehouse.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<UserClass> UserWarehouse { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
