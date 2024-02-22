using Microsoft.EntityFrameworkCore;
using Mobile.API.Entity;

namespace Mobile.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Phone>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>()
                .HasKey(c => c.Id);

            builder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
