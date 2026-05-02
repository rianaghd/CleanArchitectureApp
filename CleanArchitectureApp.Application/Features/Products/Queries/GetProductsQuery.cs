using MediatR;
using CleanArchitectureApp.Application.DTOs;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
}