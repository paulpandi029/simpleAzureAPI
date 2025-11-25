using Microsoft.EntityFrameworkCore;
using simpleAzureAPI.Models;

namespace simpleAzureAPI.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

}
