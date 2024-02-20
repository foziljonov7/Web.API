using Microsoft.EntityFrameworkCore;
using Mobile.API.Entity;

namespace Mobile.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
    }
}
