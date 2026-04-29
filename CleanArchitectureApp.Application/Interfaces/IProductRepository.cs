using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
}