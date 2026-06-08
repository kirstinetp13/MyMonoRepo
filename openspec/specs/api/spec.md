# API Domain Specification

## Overview

The API domain encompasses all HTTP endpoints, request/response contracts, and routing behavior for MyMonoRepo. It follows vertical slice architecture where each feature is encapsulated with its own handlers, models, and endpoints.

**Architecture Pattern**: Vertical Slices with CQRS  
**Tech Stack**: .NET 10, C# 14, MediatR  
**Documentation**: https://jimmybogard.com/vertical-slice-architecture/

---

## Requirements

### Requirement: Health Check Endpoint
The system MUST expose a health check endpoint that returns status information without authentication.

#### Scenario: Root endpoint responds
- GIVEN the API is running
- WHEN a GET request is made to `/`
- THEN a 200 OK response is returned
- AND the body contains "Welcome to MyMonoRepo API"

---

### Requirement: Vertical Slice Feature Pattern
The system SHALL implement features using vertical slice architecture where each slice contains its own query/command handlers, DTOs, and endpoints.

#### Scenario: Feature encapsulation
- GIVEN a new feature needs to be added
- WHEN the feature is implemented under `Features/{FeatureName}/`
- THEN it includes:
  - `{FeatureName}Query.cs` or `{FeatureName}Command.cs` (MediatR request)
  - `{FeatureName}Handler.cs` (MediatR handler)
  - `{FeatureName}Dto.cs` (data transfer objects)
  - `{FeatureName}Endpoints.cs` (minimal API endpoints)

---

### Requirement: MediatR Request/Response Pattern
The system SHALL use MediatR for decoupling requests from handlers following the CQRS pattern.

#### Scenario: Query handling
- GIVEN a query request is sent via MediatR
- WHEN the mediator processes the request
- THEN the appropriate handler executes
- AND a typed response is returned

---

### Requirement: Minimal API Endpoints
The system SHALL define endpoints using .NET Minimal APIs with explicit names and descriptions.

#### Scenario: Endpoint mapping
- GIVEN endpoints are mapped to the application
- WHEN a request matches the endpoint pattern
- THEN the handler is invoked
- AND response is serialized to JSON (default)

---

### Requirement: Dependency Injection
The system SHALL use constructor injection for all dependencies via .NET's built-in DI container.

#### Scenario: Service resolution
- GIVEN services are registered in Program.cs
- WHEN a handler requests a dependency
- THEN the DI container provides the requested service
- AND the handler executes with fully-resolved dependencies

---

### Requirement: OpenAPI Support
The system MAY expose OpenAPI specification for API documentation and tooling integration.

#### Scenario: OpenAPI generation
- GIVEN the API is running in development mode
- WHEN `/openapi/v1.json` is requested
- THEN the OpenAPI schema is returned
- AND endpoints have metadata for documentation

---

## Constraints

- **Security First**: No endpoints bypass authentication/authorization without explicit override
- **Pattern Consistency**: All new features MUST follow vertical slice pattern
- **Error Handling**: All endpoints return consistent error responses with appropriate status codes
- **Documentation**: All public endpoints MUST have descriptions and names via MapGet/MapPost etc.
- **Logging**: Important operations logged via ILogger<T>

---

## Architecture Decisions

- **Minimal APIs**: Chosen over MVC for lightweight, functional endpoint definition
- **MediatR**: Provides clear separation between request/response and handler concerns
- **Vertical Slices**: Each feature owns its vertical layer for better maintainability
- **Built-in DI**: No external DI container needed for .NET 10

Reference: [Clean Architecture](https://learn.microsoft.com/aspnet/architecture/)
