# CleanArchitectureApp

A fully functional REST API built with ASP.NET Core 10, following Clean Architecture principles with CQRS, MediatR, Entity Framework Core, JWT Authentication, and FluentValidation.

---

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Design Patterns](#design-patterns)

---

## Architecture Overview

The project is split into 4 layers following Clean Architecture principles:

```
CleanArchitectureApp.API           → Controllers, Swagger, Program.cs
CleanArchitectureApp.Application   → CQRS, MediatR, DTOs, Interfaces, Validators, Behaviours
CleanArchitectureApp.Infrastructure → EF Core, Repositories, DbContext
CleanArchitectureApp.Domain        → Entities (pure, no dependencies)
```

Dependency flow:
```
API → Application → Domain
Infrastructure → Domain/Application (via interfaces)
```

The Domain layer has zero external dependencies. All database and framework concerns are kept in Infrastructure. The Application layer defines interfaces that Infrastructure implements — this is the Dependency Inversion Principle in action.

---

## Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core 10 | Web API framework |
| Entity Framework Core 10 | ORM for database access |
| PostgreSQL | Relational database |
| MediatR 11 | CQRS + mediator pattern |
| AutoMapper 13 | Object-to-DTO mapping |
| FluentValidation | Request validation |
| JWT Bearer Auth | Authentication |
| BCrypt.Net | Password hashing |
| Swashbuckle 6 | Swagger UI |

---

## Project Structure

```
CleanArchitectureApp/
│
├── CleanArchitectureApp.Domain/
│   └── Entities/
│       ├── Product.cs
│       ├── Category.cs
│       └── User.cs
│
├── CleanArchitectureApp.Application/
│   ├── Behaviours/
│   │   ├── ValidationBehavior.cs
│   │   └── LoggingBehavior.cs
│   ├── DTOs/
│   │   ├── ProductDto.cs
│   │   ├── CategoryDto.cs
│   │   ├── LoginRequest.cs
│   │   └── RegisterRequest.cs
│   ├── Interfaces/
│   │   ├── IProductRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   └── IUserRepository.cs
│   ├── Mappings/
│   │   └── MappingProfile.cs
│   └── Features/
│       ├── Products/
│       │   ├── Commands/
│       │   │   ├── CreateProductCommand.cs + Handler
│       │   │   ├── UpdateProductCommand.cs + Handler
│       │   │   └── DeleteProductCommand.cs + Handler
│       │   ├── Queries/
│       │   │   ├── GetProductsQuery.cs + Handler
│       │   │   └── GetProductByIdQuery.cs + Handler
│       │   └── Validators/
│       │       ├── CreateProductCommandValidator.cs
│       │       └── UpdateProductCommandValidator.cs
│       └── Categories/
│           ├── Commands/
│           │   ├── CreateCategoryCommand.cs + Handler
│           │   ├── UpdateCategoryCommand.cs + Handler
│           │   └── DeleteCategoryCommand.cs + Handler
│           ├── Queries/
│           │   ├── GetCategoriesQuery.cs + Handler
│           │   └── GetCategoryByIdQuery.cs + Handler
│           └── Validators/
│               ├── CreateCategoryCommandValidator.cs
│               └── UpdateCategoryCommandValidator.cs
│
├── CleanArchitectureApp.Infrastructure/
│   ├── Data/
│   │   └── AppDbContext.cs
│   └── Repositories/
│       ├── ProductRepository.cs
│       ├── CategoryRepository.cs
│       └── UserRepository.cs
│
└── CleanArchitectureApp.API/
    ├── Controllers/
    │   ├── ProductsController.cs
    │   ├── CategoriesController.cs
    │   └── AuthController.cs
    └── Program.cs
```

---

## Features

### ✅ Clean Architecture
- Strict separation of concerns across 4 layers
- Dependencies only point inward toward the Domain
- Domain layer has no external dependencies

### ✅ CQRS with MediatR
- Commands (write operations) and Queries (read operations) are fully separated
- Each operation has its own Command/Query class and Handler
- MediatR pipeline behaviors for cross-cutting concerns

### ✅ Repository Pattern
- `IProductRepository`, `ICategoryRepository`, `IUserRepository` defined in Application
- Implementations in Infrastructure using EF Core
- Controllers never talk to the database directly

### ✅ DTO Layer with AutoMapper
- API never exposes Domain entities directly
- `ProductDto` and `CategoryDto` separate API models from Domain models
- AutoMapper profiles handle all mapping

### ✅ Full CRUD for Products and Categories
- Create, Read (all + by ID), Update, Delete
- Both entities fully implemented end-to-end

### ✅ FluentValidation
- Validates all incoming Commands before they reach handlers
- Integrated into MediatR pipeline via `ValidationBehavior`
- Rules: required fields, max lengths, positive prices

### ✅ MediatR Pipeline Behaviors
- `ValidationBehavior` — runs FluentValidation before every handler
- `LoggingBehavior` — logs request name before and after every handler

### ✅ JWT Authentication
- Register and login endpoints
- Passwords hashed with BCrypt
- JWT tokens with issuer, audience, and expiry
- Protected endpoints return `401 Unauthorized` without a valid token

### ✅ Swagger UI
- Full API documentation at `/swagger`
- JWT Authorize button for testing protected endpoints

---

## Getting Started

### Prerequisites
- .NET 10 SDK
- PostgreSQL running locally

### Database Setup
Update the connection string in `Program.cs` if needed:
```
Host=localhost;Port=5432;Database=cleanarchitecturedb;Username=postgres;Password=yourpassword
```

### Run Migrations
```bash
dotnet ef migrations add InitialCreate --project CleanArchitectureApp.Infrastructure --startup-project CleanArchitectureApp.API
dotnet ef database update --project CleanArchitectureApp.Infrastructure --startup-project CleanArchitectureApp.API
```

### Run the API
```bash
dotnet run --project CleanArchitectureApp.API
```

Open Swagger at: `http://localhost:5058/swagger`

---

## API Endpoints

### Auth
| Method | Endpoint | Description | Auth Required |
|---|---|---|---|
| POST | /api/auth/register | Register a new user | No |
| POST | /api/auth/login | Login and get JWT token | No |

### Products
| Method | Endpoint | Description | Auth Required |
|---|---|---|---|
| GET | /api/products | Get all products | ✅ Yes |
| GET | /api/products/{id} | Get product by ID | ✅ Yes |
| POST | /api/products | Create a product | ✅ Yes |
| PUT | /api/products/{id} | Update a product | ✅ Yes |
| DELETE | /api/products/{id} | Delete a product | ✅ Yes |

### Categories
| Method | Endpoint | Description | Auth Required |
|---|---|---|---|
| GET | /api/categories | Get all categories | ✅ Yes |
| GET | /api/categories/{id} | Get category by ID | ✅ Yes |
| POST | /api/categories | Create a category | ✅ Yes |
| PUT | /api/categories/{id} | Update a category | ✅ Yes |
| DELETE | /api/categories/{id} | Delete a category | ✅ Yes |

---

## Authentication

1. Register a user via `POST /api/auth/register`
2. Login via `POST /api/auth/login` to receive a JWT token
3. In Swagger, click the **Authorize** 🔒 button
4. Enter your token and click Authorize
5. All protected endpoints will now work

---

## Design Patterns

### CQRS (Command Query Responsibility Segregation)
Commands mutate state (Create, Update, Delete). Queries only read state (Get, GetById). They are never mixed, keeping each operation focused and testable.

### Mediator Pattern
Controllers don't call repositories or services directly. They send a Command or Query to MediatR, which routes it to the correct Handler. This decouples the API layer from the Application layer.

### Repository Pattern
Repositories abstract the database layer. The Application layer depends only on interfaces (`IProductRepository`), not on EF Core. This makes the code testable and swappable.

### Pipeline Behaviors
MediatR pipeline behaviors run before and after every handler, similar to middleware but scoped to individual requests. This project uses `ValidationBehavior` and `LoggingBehavior` for cross-cutting concerns.

### Dependency Injection
All services, repositories, handlers, validators, and behaviors are registered in `Program.cs` and injected automatically by the ASP.NET Core DI container.