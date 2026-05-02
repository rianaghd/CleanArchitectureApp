using MediatR;
using CleanArchitectureApp.Application.DTOs;

namespace CleanArchitectureApp.Application.Features.Categories.Queries;

public class GetCategoriesQuery : IRequest<List<CategoryDto>>
{
}