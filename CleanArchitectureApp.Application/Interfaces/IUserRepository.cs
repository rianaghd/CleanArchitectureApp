using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}