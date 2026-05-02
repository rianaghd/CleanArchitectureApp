using Microsoft.EntityFrameworkCore;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users => Set<User>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Categories
        modelBuilder.Entity<Category>().HasData( //ef core seed
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Books" }
        );
    }
}