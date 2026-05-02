using AutoMapper;
using MediatR;
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = _repository.GetById(request.Id);
        var dto = _mapper.Map<ProductDto?>(product);
        return Task.FromResult(dto);
    }
}