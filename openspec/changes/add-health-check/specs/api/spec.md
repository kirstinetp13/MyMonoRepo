# Delta for API

## ADDED Requirements

### Requirement: Health Check Endpoint
The system MUST provide a health check endpoint for monitoring and orchestration tools.

#### Scenario: Health check response
- GIVEN the API is running
- WHEN GET `/health` is requested
- THEN a 200 OK response is returned with JSON body:
  ```json
  {
    "status": "Healthy",
    "timestamp": "2025-06-08T14:47:57Z",
    "uptime": { "seconds": 3600, "formatted": "1h 0m 0s" },
    "version": "1.0.0"
  }
  ```
- AND the endpoint does NOT require authentication
- AND the endpoint can be called multiple times without side effects

#### Scenario: Status indicates health
- GIVEN the health check is performed
- WHEN all systems are operational
- THEN status is "Healthy"
- AND HTTP status code is 200 OK

---

## Notes

- Uses MediatR query pattern for CQRS separation
- Vertical slice in `Features/HealthCheck/`
- No external dependencies (uses built-in .NET types)
- Extensible for future health checks (database, external services, etc.)

Reference: [Health Checks Best Practices](https://learn.microsoft.com/aspnet/core/host-and-deploy/health-checks)
