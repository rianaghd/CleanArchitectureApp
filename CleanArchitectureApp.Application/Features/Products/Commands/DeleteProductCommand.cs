using MediatR;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}