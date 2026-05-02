using MediatR;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Products.Queries;

public class GetProductsQuery : IRequest<List<Product>>
{
}