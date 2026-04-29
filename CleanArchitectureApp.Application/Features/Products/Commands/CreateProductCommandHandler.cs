using MediatR;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    // Repository used to handle product data operations
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        // Injecting repository via Dependency Injection
        _repository = repository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Creating a new Product entity from request
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        // Saving product using repository (not DbContext directly)
        await _repository.AddAsync(product);

        // Returning generated product id
        return product.Id;
    }
}