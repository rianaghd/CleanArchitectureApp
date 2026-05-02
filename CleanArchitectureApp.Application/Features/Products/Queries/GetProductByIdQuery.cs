using MediatR;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<Product?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}