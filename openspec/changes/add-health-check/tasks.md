# Tasks: Health Check Endpoint

## 1. Create MediatR Query & Handler

- [ ] 1.1 Create `GetHealthQuery.cs` record (MediatR IRequest)
- [ ] 1.2 Create `HealthCheckDto` with Status, Timestamp, Uptime, Version
- [ ] 1.3 Create `GetHealthQueryHandler` implementing IRequestHandler
- [ ] 1.4 Implement handler logic:
  - Get current time
  - Calculate uptime from process start
  - Determine status (Healthy for now)
  - Return DTO

## 2. Create Endpoint

- [ ] 2.1 Create `HealthCheckEndpoints.cs` static class
- [ ] 2.2 Add `MapHealthCheckEndpoints()` extension method
- [ ] 2.3 Register `GET /health` endpoint
- [ ] 2.4 Inject `IMediator` in endpoint handler
- [ ] 2.5 Send `GetHealthQuery` and return result

## 3. Integration

- [ ] 3.1 Add `using HealthCheckFeature;` in `Program.cs`
- [ ] 3.2 Call `app.MapHealthCheckEndpoints();` in `Program.cs`
- [ ] 3.3 Verify endpoint is registered

## 4. Testing

- [ ] 4.1 Test via `curl http://localhost:5000/health`
- [ ] 4.2 Verify response format (JSON valid)
- [ ] 4.3 Verify status code is 200
- [ ] 4.4 Verify no authentication required

## 5. Documentation

- [ ] 5.1 Add endpoint description to `.openapi/openapi.yml`
- [ ] 5.2 Document response schema
- [ ] 5.3 Update README with new endpoint

## Notes

**Estimate**: 2 hours total  
**Pattern Reference**: [Vertical Slice](https://jimmybogard.com/vertical-slice-architecture/)  
**Owner**: Start with this to familiarize with vertical slice pattern
