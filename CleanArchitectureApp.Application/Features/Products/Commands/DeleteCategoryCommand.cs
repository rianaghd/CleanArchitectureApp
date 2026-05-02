using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands;

public class DeleteCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}