using MediatR;
using CleanArchitectureApp.Application.DTOs;

namespace CleanArchitectureApp.Application.Features.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}