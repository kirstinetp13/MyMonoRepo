# Quality Control Specification

## Overview
This specification defines project-wide quality and safety requirements that must be met before code is considered ready for review and merging. It complements domain specs (API, Infrastructure) and is authoritative for quality gates.

## Requirements

### Requirement: Minimum Test Coverage
- The project SHALL strive for a minimum of 80% code coverage measured across the managed code base (unit + integration tests).
- Coverage reports MUST be produced by CI and stored as build artifacts for auditability.
- If coverage falls below the threshold, the CI job should be marked as failed and the change should not be approved for merge until coverage is brought up.

#### Scenario: Coverage enforcement
- GIVEN a feature branch with new code
- WHEN CI runs the test suite
- THEN CI publishes a coverage report
- AND CI fails the pipeline if coverage is below 80%

---

### Requirement: No Injection Vulnerabilities
- The system MUST prevent SQL injection and other injection classes (command injection, LDAP injection, XPath injection, etc.).
- All data-access code MUST use parameterized queries, prepared statements, or an ORM that parameterizes inputs by default.
- User-controlled input MUST be validated and sanitized according to the input's expected schema; avoid manual string concatenation into commands or queries.

#### Scenario: Data access safety
- GIVEN a code change that interacts with external systems or databases
- WHEN code is reviewed and tested
- THEN tests and static analysis should validate that parameters are bound and no concatenated query strings are present

---

### Requirement: Tests Passing and Health Checks
- 100% of tests in the CI run MUST pass before the Reviewer agent can mark the review as complete.
- All configured health checks MUST return healthy status in CI integration tests before merge.

#### Scenario: Pre-merge verification
- GIVEN a PR targeting main
- WHEN CI completes
- THEN all tests pass, coverage is at/above threshold, and health checks report healthy
- AND the Reviewer may proceed to full review

---

## Enforcement & Tooling Recommendations
- Add coverage tooling to CI (e.g., coverlet, ReportGenerator) and fail the build when coverage < 80%.
- Run static analysis tools and SAST scanners to detect injection patterns and insecure coding practices.
- Include contract and integration tests for health checks.

## Notes
- Thresholds are a team-level target. For legacy code, use gradual coverage goals and document exemptions in the devlog.
- Final enforcement is implemented via CI configuration and the Reviewer agent's checklist.
