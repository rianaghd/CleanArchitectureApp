using MediatR;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductByIdQueryHandler 
    : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly IProductRepository _repository;

    public GetProductByIdQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_repository.GetAll());
    }
}