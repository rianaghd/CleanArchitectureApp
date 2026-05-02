using MediatR;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _repository.GetById(request.Id);

        if (product is null)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

        product.Name = request.Name;
        product.Price = request.Price;

        await _repository.UpdateAsync(product);
        return Unit.Value;
    }
}