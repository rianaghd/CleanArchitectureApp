using AutoMapper;
using MediatR;
using CleanArchitectureApp.Application.DTOs;
using CleanArchitectureApp.Application.Interfaces;

namespace CleanArchitectureApp.Application.Features.Categories.Queries;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _repository.GetAll();
        return Task.FromResult(_mapper.Map<List<CategoryDto>>(categories));
    }
}