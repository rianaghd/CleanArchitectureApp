using MediatR;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category { Name = request.Name };
        await _repository.AddAsync(category);
        return Unit.Value;
    }
}