# Repository instructions

## Purpose

PadelTrialSchedule is a read-only trial-training schedule: an ASP.NET Core API, PostgreSQL/EF Core persistence, and a React client. Keep the product scope narrow; booking and payment are intentionally out of scope.

## Architecture boundaries

- `Domain` owns entities, enums, and business invariants. It must not reference other projects.
- `Application` owns contracts, queries, and abstractions. It may reference `Domain`.
- `Infrastructure` implements persistence and application abstractions.
- `Api` owns HTTP composition, transport concerns, and SPA hosting.
- `ClientApp` consumes only the public HTTP contract.
- Tests may reference any production project but production projects must never reference tests.

Do not move EF Core or HTTP concerns into `Domain`. Avoid adding a repository abstraction when a focused query service is sufficient.

## Required workflow

Before changing code:

1. Read `README.md` and the nearest project files.
2. Identify the affected boundary and existing tests.
3. Keep API changes backward-compatible unless the task explicitly changes the contract.

Run before finishing:

```bash
dotnet test PadelTrialSchedule.sln --configuration Release
cd src/PadelTrialSchedule.ClientApp
npm ci
npm run lint
npm run test
npm run build
```

For Docker or persistence changes also run:

```bash
docker compose config --quiet
docker compose build
```

## Conventions and guardrails

- Nullable reference types and warnings-as-errors are intentional; do not suppress warnings globally.
- Use async EF Core calls and pass `CancellationToken` through request and query paths.
- Keep migrations additive and committed with the model snapshot.
- Never commit credentials, personal data, or production connection strings.
- Preserve loading, empty, error, keyboard, and mobile states in the client.
- Prefer the smallest dependency set that solves the requirement.

## Definition of done

A change is complete only when the relevant tests pass, setup documentation still matches reality, errors remain observable, and the diff does not cross an architecture boundary without an explicit reason.

