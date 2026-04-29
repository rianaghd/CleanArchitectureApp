using MediatR;

namespace CleanArchitectureApp.Application.Features.Products.Commands;

// Detta är en "request" (vi vill skapa en product)
public class CreateProductCommand : IRequest<int>
{
    // Data som kommer från API:t
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}