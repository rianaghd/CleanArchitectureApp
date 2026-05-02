using AutoMapper;
using MediatR;
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _repository.GetAll();
        var dtos = _mapper.Map<List<ProductDto>>(products);
        return Task.FromResult(dtos);
    }
}