using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Interfaces;

public interface ICategoryRepository
{
    List<Category> GetAll();
    Category? GetById(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}