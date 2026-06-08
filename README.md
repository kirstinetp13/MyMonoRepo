# MyMonoRepo

[![CI](https://github.com/kirstinetp13/MyMonoRepo/actions/workflows/ci.yml/badge.svg)](https://github.com/kirstinetp13/MyMonoRepo/actions/workflows/ci.yml)

A modern .NET 10 monorepo optimized for vertical slices, clean architecture, and GitHub Copilot CLI integration.

## Architecture

This project follows **vertical slice architecture** to keep features encapsulated and maintainable:
- Each feature lives in its own "slice" under `src/MyMonoRepo.Api/Features/`
- Slices include handlers (MediatR), DTOs, validators, and endpoints
- Shared logic lives in `Common/` and `Infrastructure/` folders

**Docs**: [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)

## Project Structure

```
MyMonoRepo/
├── src/
│   └── MyMonoRepo.Api/             # Main API project (.NET 10, C# 14)
│       ├── Features/                # Vertical slices (each feature here)
│       ├── Common/                  # Shared utilities and extensions
│       ├── Infrastructure/          # Data access, external services
│       └── Program.cs              # Minimal API host
├── docs/
│   ├── agents/                     # Agent personas (e.g., AGENT-Programmer.md)
│   └── specs/                      # Architecture and design docs
├── .openapi/                       # OpenAPI/Swagger specifications
├── .github/
│   ├── copilot-setup-steps.yml    # GitHub Copilot CLI configuration
│   └── workflows/                  # GitHub Actions
├── tests/                          # Test projects (unit, integration)
└── MyMonoRepo.sln                 # Global solution file
```

## Quick Start

### Prerequisites
- .NET 10 SDK
- Visual Studio 2022 or VS Code with C# Dev Kit

### Build & Run

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build MyMonoRepo.sln

# Run API
cd src/MyMonoRepo.Api
dotnet run

# Open browser
# http://localhost:5000
# Swagger UI: http://localhost:5000/swagger
```

### Run Tests

```bash
dotnet test MyMonoRepo.sln
```

## Development Guidelines

Follow the **Programmer** agent persona for code style and patterns:
- See: [docs/agents/AGENT-Programmer.md](docs/agents/AGENT-Programmer.md)

Code reviews are handled by the **Reviewer** agent:
- See: [docs/agents/AGENT-Reviewer.md](docs/agents/AGENT-Reviewer.md)
- Role: Validate code against standards, security, specifications, and scope
- Note: Reviewer does NOT produce code, only provides feedback

Key principles:
- **Write clear, easy-to-read, well-commented code** (Programmer)
- **All code is reviewed for standards & security** (Reviewer)
- **Refuse security risks** (no secrets in code, use secret managers)
- **Use vertical slices** to organize features
- **Prefer patterns**: CQRS/MediatR, DI, Clean Architecture
- **Test all new behavior** (unit or integration tests required)

### Spec-Driven Development with OpenSpec

This project uses **OpenSpec** for spec-driven development. All features start with specifications before coding.

**Get started:**
1. Review the specs: `openspec/specs/` (API, Infrastructure)
2. Check out example change: `openspec/changes/add-health-check/`
3. Create new changes: `openspec/changes/{feature-name}/`
4. Follow the workflow: proposal → design → tasks → implement → archive

See [OpenSpec Setup Guide](openspec/README.md) for detailed instructions.

**Workflow:**
```
proposal (intent) ──► design (technical) ──► tasks (checklist) ──► implement ──► archive
```

## Patterns & References

| Pattern | Purpose | Docs |
|---------|---------|------|
| Vertical Slice Architecture | Feature encapsulation | [jimmybogard.com](https://jimmybogard.com/vertical-slice-architecture/) |
| CQRS & MediatR | Separation of reads/writes | [MediatR GitHub](https://github.com/jbogard/MediatR) |
| Dependency Injection | Loose coupling | [Microsoft Docs](https://learn.microsoft.com/dotnet/core/extensions/dependency-injection) |
| Clean Architecture | Domain isolation | [Microsoft Architecture Guide](https://learn.microsoft.com/aspnet/architecture/) |

## GitHub Copilot CLI Integration

This monorepo is optimized for **GitHub Copilot CLI** via `.github/copilot-setup-steps.yml`:
- Auto-installs .NET 10 and dependencies
- Runs build and test commands automatically
- Loads the **Programmer** agent for smart code suggestions

## Creating a New Feature (Vertical Slice)

1. Create a folder under `src/MyMonoRepo.Api/Features/YourFeatureName/`
2. Add subdirectories:
   - `Commands/` or `Queries/` (MediatR handlers)
   - `Endpoints/` (Minimal API endpoints)
   - `Models/` (DTOs, request/response)
   - `Validators/` (FluentValidation, if needed)

3. Register in `Program.cs` (or use MediatR auto-registration)

4. Add tests in `tests/MyMonoRepo.Api.Tests/Features/YourFeatureName/`

Example structure:
```
Features/
└── YourFeatureName/
    ├── Commands/
    │   └── CreateYourFeatureCommand.cs
    ├── Queries/
    │   └── GetYourFeatureQuery.cs
    ├── Endpoints/
    │   └── YourFeatureEndpoints.cs
    └── Models/
        ├── YourFeatureDto.cs
        └── CreateYourFeatureRequest.cs
```

## Contributing

1. Create a feature branch
2. Implement your slice (handlers, endpoints, models)
3. Add tests
4. Submit a PR with:
   - Clear title and description
   - Tests for new behavior
   - Alignment with vertical slice boundaries

## License

TBD

## References

- [.NET 10 Documentation](https://learn.microsoft.com/dotnet/)
- [Clean Architecture](https://learn.microsoft.com/aspnet/architecture/)
- [Monorepo Best Practices](https://martinfowler.com/articles/monorepos.html)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
