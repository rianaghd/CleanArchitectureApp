using MediatR;
using CleanArchitectureApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Infrastructure.Repositories;
using CleanArchitectureApp.Application.Features.Products.Commands;
using CleanArchitectureApp.Application.Features.Products.Queries;

var builder = WebApplication.CreateBuilder(args);

// Registers controller support for the Web API
builder.Services.AddControllers();

// Enables Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers MediatR and scans the Application layer for all Commands, Queries, and Handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetProductsQuery).Assembly);
});

// Registers the Entity Framework DbContext with PostgreSQL database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=cleanarchitecturedb;Username=postgres;Password=Riana1380!")
);

// Registers the repository implementation for dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Enables Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirects HTTP requests to HTTPS
app.UseHttpsRedirection();

// Maps controller endpoints
app.MapControllers();

// Starts the application
app.Run();