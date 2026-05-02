using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitectureApp.Application.Features.Products.Commands;
using CleanArchitectureApp.Application.Features.Products.Queries;

namespace CleanArchitectureApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }
}