using Edu.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Edu.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherId);

        base.OnModelCreating(builder);
    }
}
