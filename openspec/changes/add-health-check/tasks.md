# Tasks: add-health-check

TDD & Implementation Tasks
--------------------------
1. Create test suite skeleton under tests/Features/HealthCheck/ (unit & integration).
2. Write failing unit tests for each IHealthCheck (DB, external API, disk space, config presence).
3. Write integration test asserting /health/ready returns Healthy when mocks are healthy.
4. Implement IHealthCheck classes and register via AddHealthChecksServices extension.
5. Map endpoints: /health, /health/live, /health/ready and implement JSON shaping.
6. Ensure no sensitive data in responses; redact details where necessary.
7. Add logging for degraded/unhealthy checks.
8. Update README and OpenAPI spec.
9. Add Kubernetes probe examples to docs.
10. Run CI and ensure coverage & tests pass.

CI & Release Tasks
------------------
1. Ensure integration tests are included in CI job.
2. Validate coverage does not drop below 80% (feature branch).
3. Upload coverage artifact and health-check test results.
4. Close change in OpenSpec and merge delta into main specs once Reviewer approves.

Done when
--------
- All tests pass in CI, coverage >= 80%, health endpoints return Healthy in CI integration tests, OpenSpec change set completed, and PR approved by Reviewer.
