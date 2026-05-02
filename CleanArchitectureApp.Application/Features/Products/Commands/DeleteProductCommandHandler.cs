using MediatR;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _repository.GetById(request.Id);

        if (product is null)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

        await _repository.DeleteAsync(product);
        return Unit.Value;
    }
}