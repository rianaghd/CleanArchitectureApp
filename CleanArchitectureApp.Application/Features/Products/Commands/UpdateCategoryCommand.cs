using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}