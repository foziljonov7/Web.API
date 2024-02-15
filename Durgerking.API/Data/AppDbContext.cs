using Durgerking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Durgerking.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
    }
}
