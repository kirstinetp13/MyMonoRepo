# Assignment: add-health-check — Tasks for Programmer

Branch: feature/add-health-check-20260608T162510
Owner: Programmer (assigned by Organizer)

Goal
----
Implement the add-health-check feature using TDD. Start by creating failing tests that express the acceptance checklist, then implement the minimal code to satisfy the tests.

TDD Instructions (must follow)
-----------------------------
1. Create unit tests first (tests/Features/HealthCheck/): one test per IHealthCheck (DB, external API, disk space, config presence). Tests must fail initially.
2. Create an integration test (WebApplicationFactory) asserting /health/ready returns Healthy when dependencies are healthy (use mocks/stubs). Test must fail initially.
3. Only then implement minimal IHealthCheck classes and the endpoint mapping to make tests pass.
4. Keep commits small and focused; first commit on this branch must contain the failing tests (TDD step).
5. Include test names that reference OpenSpec acceptance criteria (e.g., Health_Check_Returns_Healthy_When_Db_Available).

Acceptance Criteria (short)
---------------------------
- Failing tests committed first on the feature branch
- Unit tests for each check present and failing
- Integration test for /health/ready present and failing
- Subsequent commits implement passing tests
- Coverage remains >=80% and CI integration validates health endpoints

Commit message templates
------------------------
- "test: add failing tests for HealthCheck — TDD start"
- "feat: implement DbHealthCheck"
- "chore: map health endpoints and register checks"

Report-back
-----------
When the failing-tests commit is pushed, reply here with the commit SHA and brief summary. Organizer will then wait for subsequent commits to make tests pass and then trigger Reviewer.

Notes
-----
- Do not include secrets in tests or code.
- Use dependency injection and mocking for external dependencies.
- Keep responses in code comments short; link to docs when recommending patterns.
