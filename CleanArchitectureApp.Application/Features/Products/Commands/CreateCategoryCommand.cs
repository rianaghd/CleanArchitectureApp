using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class CreateCategoryCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
}