using MediatR;
using FluentValidation;
using CleanArchitectureApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Infrastructure.Repositories;
using CleanArchitectureApp.Application.Features.Products.Commands;
using CleanArchitectureApp.Application.Features.Products.Queries;
using CleanArchitectureApp.Application.Behaviours;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registers controller support for the Web API
builder.Services.AddControllers();

// Enables Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter your JWT token here."
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Registers MediatR and scans the Application layer for all Commands, Queries, and Handlers
builder.Services.AddMediatR(
    typeof(CleanArchitectureApp.Application.Features.Products.Queries.GetProductsQuery).Assembly
);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CleanArchitectureApp.Application.Mappings.MappingProfile>();
});

// Registers the Entity Framework DbContext with PostgreSQL database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=cleanarchitecturedb;Username=postgres;Password=Riana1380!")
);

// Registers the repository implementation for dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
// Register the validation pipeline behavior
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);

// Register all validators from Application assembly
builder.Services.AddValidatorsFromAssembly(
    typeof(CleanArchitectureApp.Application.Features.Products.Validators.CreateProductCommandValidator).Assembly
);

// Register UserRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Enables Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirects HTTP requests to HTTPS
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Maps controller endpoints
app.MapControllers();


// Starts the application
app.Run();