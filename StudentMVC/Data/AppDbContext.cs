using Microsoft.EntityFrameworkCore;
using StudentMVC.Models;

namespace StudentMVC.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().ToTable("Students");
    }
}
