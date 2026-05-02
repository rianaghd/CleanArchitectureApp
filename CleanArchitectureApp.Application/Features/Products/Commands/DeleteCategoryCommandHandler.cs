using MediatR;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _repository.GetById(request.Id);

        if (category is null)
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");

        await _repository.DeleteAsync(category);
        return Unit.Value;
    }
}