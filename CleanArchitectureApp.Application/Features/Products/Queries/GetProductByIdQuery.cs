using MediatR;
using CleanArchitectureApp.Application.DTOs;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}