# Proposal: Add Health Check Endpoint

## Intent

Provide a dedicated health check endpoint for monitoring, load balancers, and orchestration tools (Kubernetes, Azure Container Instances, etc.) to verify API availability and readiness.

## Scope

- Create `/health` endpoint that returns comprehensive status
- Include basic health checks (e.g., memory, uptime)
- Accessible without authentication
- Return standard health status format

## Approach

- Implement as a single handler with MediatR
- Use .NET's built-in HealthCheckMiddleware (extensible)
- Return JSON response with:
  - Status (Healthy, Degraded, Unhealthy)
  - Timestamp
  - Uptime
  - Component status

## Success Criteria

- ✓ `/health` endpoint responds with 200 OK
- ✓ Response includes status, timestamp, uptime
- ✓ No authentication required
- ✓ Meets Kubernetes health probe expectations

## Dependencies

- None (uses built-in .NET capabilities)

## Estimated Effort

- Design: 30 minutes
- Implementation: 1 hour
- Testing: 30 minutes
