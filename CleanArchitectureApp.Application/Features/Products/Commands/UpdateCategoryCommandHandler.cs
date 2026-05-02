using MediatR;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _repository.GetById(request.Id);

        if (category is null)
            throw new KeyNotFoundException($"Category with ID {request.Id} not found.");

        category.Name = request.Name;
        await _repository.UpdateAsync(category);
        return Unit.Value;
    }
}