# Design: Health Check Endpoint

## Technical Approach

### Endpoint Implementation
- Single MediatR query: `GetHealthQuery`
- Handler: `GetHealthQueryHandler`
- DTO: `HealthCheckDto`
- Minimal API endpoint: `GET /health`

### Response Format
```json
{
  "status": "Healthy",
  "timestamp": "2025-06-08T14:47:57Z",
  "uptime": {
    "seconds": 3600,
    "formatted": "1h 0m 0s"
  },
  "version": "1.0.0"
}
```

### Architecture Decisions

**CQRS Pattern**: Use MediatR query pattern  
Reference: https://martinfowler.com/bliki/CQRS.html

**Vertical Slice**: Place in `Features/HealthCheck/`  
Reference: https://jimmybogard.com/vertical-slice-architecture/

**Status Values**: Follow RFC 7231 HTTP semantics
- `Healthy`: All systems operational (200 OK)
- `Degraded`: Non-critical issues (200 OK)
- `Unhealthy`: Critical issues (503 Service Unavailable)

### Security
- No authentication required (public endpoint)
- Rate limiting recommended for production
- No sensitive data in response

## Implementation Plan

1. Create MediatR query and handler
2. Create response DTO
3. Create endpoint mapper
4. Register in Program.cs
5. Add to OpenAPI spec
