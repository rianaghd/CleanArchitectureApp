using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Infrastructure.Data;

namespace CleanArchitectureApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    // Constructor injection of DbContext
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    // Adds a new product to the database
    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    // Returns all products from the database
    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    // Returns a single product by its Id, or null if not found
    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    // Updates an existing product in the database
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    // Deletes a product from the database
    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}