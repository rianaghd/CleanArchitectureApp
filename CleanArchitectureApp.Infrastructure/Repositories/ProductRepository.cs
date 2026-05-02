using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.Data;

namespace CleanArchitectureApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    // Database context used to interact with the PostgreSQL database
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        // Injecting the DbContext via Dependency Injection
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        // Adds the product entity to the database context (not saved yet)
        _context.Products.Add(product);

        // Persists changes to the database (executes SQL INSERT)
        await _context.SaveChangesAsync();
    }
    
    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}