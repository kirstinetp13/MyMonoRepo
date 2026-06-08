# OpenSpec Setup for MyMonoRepo

This directory contains the OpenSpec specification framework for MyMonoRepo - a collaborative spec-driven development tool for aligning teams and AI assistants before building.

## Quick Start

### 1. Understanding the Structure

```
openspec/
├── specs/                          # Source of truth - how the system works
│   ├── api/                        # API domain specs
│   │   └── spec.md                # API requirements, scenarios, constraints
│   └── infrastructure/             # Infrastructure domain specs
│       └── spec.md                # Infrastructure requirements, scenarios
├── changes/                        # Proposed modifications (one per feature)
│   ├── archive/                   # Completed changes (audit history)
│   └── <change-name>/            # Active changes
│       ├── proposal.md            # Why, what, scope (the intent)
│       ├── design.md              # How (technical approach)
│       ├── tasks.md               # Implementation checklist
│       └── specs/                 # Delta specs showing what's changing
└── config.yaml                    # Project configuration
```

### 2. Domains

**Current domains:**

- **API** (`specs/api/spec.md`)
  - HTTP endpoints, request/response contracts
  - Vertical slice architecture pattern
  - MediatR CQRS pattern
  
- **Infrastructure** (`specs/infrastructure/spec.md`)
  - Data access, persistence, external services
  - Configuration management, logging
  - Cross-cutting concerns

### 3. Key Concepts

**Specs** = Source of truth describing how the system currently works and should work  
**Changes** = Proposed modifications with proposal, design, and tasks  
**Delta Specs** = What's changing (ADDED, MODIFIED, REMOVED)

### 4. Workflow for New Features

When proposing a new feature, create a new change:

```
openspec/changes/
└── my-feature/
    ├── proposal.md       # Intent: Why? What? Scope? Approach?
    ├── design.md         # Technical: Architecture, patterns, decisions
    ├── tasks.md          # Implementation checklist with status
    └── specs/            # Delta specs showing requirements changes
        ├── api/
        │   └── spec.md   # New API requirements (ADDED/MODIFIED/REMOVED)
        └── infrastructure/
            └── spec.md   # Infrastructure changes if needed
```

## Example: Adding a New Feature

### Step 1: Create a Change Directory

```bash
mkdir openspec/changes/user-authentication
cd openspec/changes/user-authentication
```

### Step 2: Write proposal.md

```markdown
# Proposal: Implement User Authentication

## Intent
Enable users to register and authenticate to access protected resources.

## Scope
- User registration endpoint
- Login with email/password
- JWT token generation
- Protected endpoint middleware

## Approach
- Use ASP.NET Identity for user management
- JWT Bearer tokens for authentication
- Vertical slice pattern under Features/Authentication/
```

### Step 3: Write Delta Specs

Create `openspec/changes/user-authentication/specs/api/spec.md`:

```markdown
# Delta for API

## ADDED Requirements

### Requirement: User Registration
The system MUST provide an endpoint for users to create accounts.

#### Scenario: Register new user
- GIVEN a new user with email and password
- WHEN POST /api/auth/register is called
- THEN a new user account is created
- AND a success response with JWT token is returned

## MODIFIED Requirements

### Requirement: Health Check Endpoint
The system MUST ensure health check does NOT require authentication.
(Previously: no authentication requirement mentioned explicitly)
```

### Step 4: Write design.md

```markdown
# Design: User Authentication

## Technical Approach
- Use ASP.NET Identity for user account management
- JWT tokens with 1-hour expiration
- Vertical slice: Features/Authentication/
- Dependency: Identity DbContext in Infrastructure/

## Patterns
- Command pattern for registration (MediatR)
- Middleware for token validation
- DTOs for request/response
```

### Step 5: Write tasks.md

```markdown
# Tasks

## 1. Infrastructure Setup
- [ ] 1.1 Add Microsoft.AspNetCore.Identity package
- [ ] 1.2 Create IdentityUser derived class
- [ ] 1.3 Create IdentityDbContext

## 2. Authentication Feature
- [ ] 2.1 Create RegisterUserCommand
- [ ] 2.2 Create RegisterUserHandler
- [ ] 2.3 Create RegisterEndpoint
- [ ] 2.4 Add validation

## 3. Security
- [ ] 3.1 Add JWT token generation
- [ ] 3.2 Create authentication middleware
- [ ] 3.3 Add authorization attributes
```

### Step 6: Implement

Work through the tasks checklist, updating it as you go.

### Step 7: Archive

When complete, move the change to archive:

```bash
mv openspec/changes/user-authentication openspec/changes/archive/
```

Then **manually merge** the delta specs into the main specs:

1. Copy `openspec/changes/archive/user-authentication/specs/api/spec.md` content
2. Paste into `openspec/specs/api/spec.md`
3. Reorganize sections (Requirements, then Constraints)

## Using with Copilot CLI

The OpenSpec persona is configured in `docs/agents/AGENT-Programmer.md` with these values:

```
Guidelines: Spec-driven development with OpenSpec
- Always review existing specs before proposing changes
- Updates must include delta specs in ADDED/MODIFIED/REMOVED format
- Tasks should reference requirements from specs
```

## Best Practices

1. **Write specs first** - specs are source of truth before coding
2. **Keep specs simple** - focus on behavior and constraints, not implementation details
3. **Use scenarios** - concrete examples are clearer than abstract requirements
4. **Delta specs** - explicitly mark what's new, modified, or removed
5. **Link to docs** - reference authoritative documentation for patterns and decisions
6. **Update as you learn** - refine specs during implementation as understanding evolves

## References

- [OpenSpec Documentation](https://github.com/Fission-AI/OpenSpec/blob/main/docs/getting-started.md)
- [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)
- [Clean Architecture](https://learn.microsoft.com/aspnet/architecture/)
- [CQRS Pattern](https://martinfowler.com/bliki/CQRS.html)

## Commands (When OpenSpec CLI is installed)

```bash
# Initialize OpenSpec project (already done)
openspec init

# List active changes
openspec list

# View specific change
openspec show <change-name>

# Validate specs
openspec validate

# Interactive dashboard
openspec view
```

## Next Steps

1. Review the spec files in `specs/api/` and `specs/infrastructure/`
2. Create a new change directory for your first feature
3. Write proposal → design → tasks
4. Implement following the tasks checklist
5. Archive the change when complete

---

For more information, see the [OpenSpec Getting Started Guide](https://github.com/Fission-AI/OpenSpec/blob/main/docs/getting-started.md).
