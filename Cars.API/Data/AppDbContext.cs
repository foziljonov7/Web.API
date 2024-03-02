using Cars.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        {
            
        }
    }
}
