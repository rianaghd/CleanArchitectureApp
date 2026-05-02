using MediatR;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}