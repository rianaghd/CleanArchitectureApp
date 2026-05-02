using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);

    List<Product> GetAll();

    Product? GetById(int id);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}