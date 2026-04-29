# CleanArchitectureApp
# 🛒 Clean Architecture E-commerce API

This project is an ASP.NET Core Web API built using Clean Architecture principles.  
It follows CQRS with MediatR, Repository Pattern, and PostgreSQL with Entity Framework Core.

---

## 🏗 Architecture

The solution is split into 4 layers:

### 🔵 API Layer
- Controllers
- Swagger/OpenAPI
- HTTP endpoints
- Handles incoming requests

### 🟡 Application Layer
- CQRS (Commands & Queries)
- MediatR Handlers
- Interfaces
- Business logic coordination

### 🟢 Domain Layer
- Entities (Product, Category)
- Core business models
- Interfaces (abstractions)

### 🟣 Infrastructure Layer
- DbContext (EF Core)
- Repositories
- Database configuration
- Migrations
- PostgreSQL integration

---

## ⚙️ Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- MediatR (CQRS pattern)
- Swagger / OpenAPI

---

## 🧩 Features Implemented So Far

### ✔ Architecture
- Clean Architecture structure (4 projects)
- Dependency flow from outer → inner layers

### ✔ Database
- PostgreSQL connected via EF Core
- DbContext configured (`AppDbContext`)
- Migrations created and applied
- Seed data for Categories

### ✔ Domain
- Product entity
- Category entity
- Relationship: Category → Products (1-to-many)

### ✔ Application Layer
- CQRS implemented (Commands)
- `CreateProductCommand`
- `CreateProductCommandHandler`
- MediatR integrated

### ✔ Infrastructure
- ProductRepository implemented
- Repository Pattern used
- EF Core DbContext handling persistence

### ✔ API Layer
- Swagger enabled
- ProductsController created
- POST endpoint for product creation working

---

## 🔄 CQRS Flow

1. HTTP Request (POST /products)
2. Controller receives request
3. MediatR sends Command
4. Handler processes business logic
5. Repository saves to database
6. EF Core commits changes
7. Response returned (Product ID)

---

## 🗄 Database Setup

PostgreSQL used:

- Database: `cleanarchitecturedb`
- Connection via `Npgsql`
- Migrations applied successfully

---

## 🚀 Current Status

The project is currently in a **working backend foundation stage**:
- Product creation works
- Database connection is stable
- Clean Architecture is correctly implemented

---

## ❗ Known Limitations

- No full CRUD yet (only CREATE implemented)
- No DTOs (entities exposed directly in API)
- No authentication (JWT not implemented)
- No validation layer (FluentValidation missing)
- No AutoMapper
- No role-based access

---

## 🧭 Next Steps (Roadmap)

### 1. Complete CRUD
- [ ] GET all products
- [ ] GET product by id
- [ ] UPDATE product
- [ ] DELETE product

---

### 2. Improve Architecture
- [ ] Add DTOs (Application layer)
- [ ] Add AutoMapper profiles
- [ ] Remove direct entity exposure from API

---

### 3. Validation Layer
- [ ] Add FluentValidation
- [ ] Add MediatR Pipeline Behavior
- [ ] Validate commands before execution

---

### 4. Authentication (VG level)
- [ ] Add JWT authentication
- [ ] Login endpoint
- [ ] Token generation

---

### 5. Authorization
- [ ] Role-based access (Admin/User)
- [ ] Protect endpoints with [Authorize]

---

### 6. Polish & Best Practices
- [ ] Improve error handling (global exception middleware)
- [ ] Improve API responses (consistent DTO responses)
- [ ] Add logging behavior (MediatR pipeline)

---

## 📌 Summary

This project demonstrates:
- Clean Architecture
- CQRS pattern with MediatR
- Repository Pattern
- PostgreSQL + EF Core integration
- Working API with Swagger

It is currently a **solid backend foundation (~70% complete)** and is being extended toward full production-level structure.