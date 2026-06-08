# Design: Add Health Check Endpoints

Overview
--------
Use .NET built-in Health Checks (Microsoft.Extensions.Diagnostics.HealthChecks) and minimal API endpoints to implement liveness and readiness probes. Implement pluggable IHealthCheck implementations for each dependency.

Key Decisions
-------------
- Endpoints: /health (composite), /health/live (liveness), /health/ready (readiness)
- Use HealthCheckService to aggregate checks and translate to a structured JSON response.
- Implement checks as small classes implementing IHealthCheck and register via DI.
- Database check: attempt an open/close of a lightweight connection or run a simple test query using parameterized queries.
- External API check: use a configurable HttpClient and lightweight HEAD/GET to expected endpoint; timeout short (e.g., 1s).
- Disk space: check available free space on configured volume and fail if below threshold.
- Config presence: verify required config keys exist and are non-empty.

Testing Strategy
----------------
- TDD: write unit tests for each IHealthCheck with mocked dependencies.
- Integration test: host WebApplicationFactory for the API and assert /health/ready returns Healthy when dependencies are mocked to healthy states.
- CI will include an integration step that runs health endpoint checks.

DI & Registration
-----------------
- Use extension method AddHealthChecksServices(this IServiceCollection services, IConfiguration config) to centralize registration.
- Allow per-environment conditional checks (e.g., stub external checks in dev).

Security & Privacy
------------------
- Health responses MUST NOT include secrets (connection strings, tokens, credentials).
- Details field should be limited and scrubbed of sensitive values.

Operational Notes
-----------------
- Provide example Kubernetes liveness/readiness probe snippets in documentation.
- Emit structured logs when checks degrade.
- Consider exposing minimal metrics for alerting integration.

Implementation Plan
-------------------
1. Create per-check IHealthCheck implementations
2. Write unit tests (TDD) for each check
3. Create integration tests for endpoints
4. Register checks and map endpoints in Program.cs
5. Update OpenAPI and README
