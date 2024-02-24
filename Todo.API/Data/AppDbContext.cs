using Microsoft.EntityFrameworkCore;
using Todo.API.Entity;

namespace Todo.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoModel>()
                .HasKey(t => t.Id);

            builder.Entity<TodoModel>()
                .Property(t => t.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<TodoModel>()
                .Property(t => t.Description)
                .HasMaxLength(250);

            base.OnModelCreating(builder);
        }
    }
}
