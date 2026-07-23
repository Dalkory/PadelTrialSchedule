# Padel Trial Schedule

Ð’Ð¸Ð´Ð¶ÐµÑ‚ Ñ€Ð°ÑÐ¿Ð¸ÑÐ°Ð½Ð¸Ñ Ð¿ÐµÑ€Ð²Ñ‹Ñ… Ð¿Ñ€Ð¾Ð±Ð½Ñ‹Ñ… Ñ‚Ñ€ÐµÐ½Ð¸Ñ€Ð¾Ð²Ð¾Ðº Ð¿Ð¾ Ð¿Ð°Ð´ÐµÐ»Ñƒ Ð² Ñ„Ð¾Ñ€Ð¼Ð°Ñ‚Ðµ Ñ‚ÑƒÑ€Ð½Ð¸Ñ€Ð½Ð¾Ð¹ Ð»ÐµÐ½Ñ‚Ñ‹. ÐŸÐ¾Ð»ÑŒÐ·Ð¾Ð²Ð°Ñ‚ÐµÐ»ÑŒ Ð²Ñ‹Ð±Ð¸Ñ€Ð°ÐµÑ‚ Ð´Ð°Ñ‚Ñƒ, Ð³Ð¾Ñ€Ð¾Ð´, ÑÑ‚Ð°Ð½Ñ†Ð¸ÑŽ, Ñ‚Ñ€ÐµÐ½ÐµÑ€Ð° Ð¸ Ñ„Ð¾Ñ€Ð¼Ð°Ñ‚, Ð²Ð¸Ð´Ð¸Ñ‚ Ð·Ð°Ð¿Ð¾Ð»Ð½ÑÐµÐ¼Ð¾ÑÑ‚ÑŒ Ð³Ñ€ÑƒÐ¿Ð¿Ñ‹ Ð¸ Ð¾Ñ‚ÐºÑ€Ñ‹Ð²Ð°ÐµÑ‚ Ð¿Ð¾Ð´Ñ€Ð¾Ð±Ð½Ð¾ÑÑ‚Ð¸ Ñ‚Ñ€ÐµÐ½Ð¸Ñ€Ð¾Ð²ÐºÐ¸. Ð—Ð°Ð¿Ð¸ÑÑŒ Ð¸ Ð¾Ð¿Ð»Ð°Ñ‚Ð° Ð½Ð°Ð¼ÐµÑ€ÐµÐ½Ð½Ð¾ Ð½Ðµ Ñ€ÐµÐ°Ð»Ð¸Ð·Ð¾Ð²Ð°Ð½Ñ‹ ÑÐ¾Ð³Ð»Ð°ÑÐ½Ð¾ ÑƒÑÐ»Ð¾Ð²Ð¸ÑŽ Ð·Ð°Ð´Ð°Ð½Ð¸Ñ.

![Desktop preview](docs/preview.png)

## Sample audit

This repository also includes a [sample .NET Backend & AI Readiness Audit](docs/sample-audit-report.md) with an architecture map, evidence-backed findings, priorities, and implementation estimates.

## Ð‘Ñ‹ÑÑ‚Ñ€Ñ‹Ð¹ ÑÑ‚Ð°Ñ€Ñ‚

ÐÑƒÐ¶ÐµÐ½ Ñ‚Ð¾Ð»ÑŒÐºÐ¾ Docker Desktop.

```bash
docker compose up --build
```

ÐŸÐ¾ÑÐ»Ðµ Ð·Ð°Ð¿ÑƒÑÐºÐ° Ð¿Ñ€Ð¸Ð»Ð¾Ð¶ÐµÐ½Ð¸Ðµ Ð´Ð¾ÑÑ‚ÑƒÐ¿Ð½Ð¾ Ð½Ð° [http://localhost:18080](http://localhost:18080). ÐÐ° Windows Ð¼Ð¾Ð¶Ð½Ð¾ Ð¿Ñ€Ð¾ÑÑ‚Ð¾ Ð·Ð°Ð¿ÑƒÑÑ‚Ð¸Ñ‚ÑŒ `run.cmd` Ð´Ð²Ð¾Ð¹Ð½Ñ‹Ð¼ ÐºÐ»Ð¸ÐºÐ¾Ð¼.

ÐžÑÑ‚Ð°Ð½Ð¾Ð²Ð¸Ñ‚ÑŒ Ð¿Ñ€Ð¸Ð»Ð¾Ð¶ÐµÐ½Ð¸Ðµ:

```bash
docker compose down
```

Ð”Ð°Ð½Ð½Ñ‹Ðµ PostgreSQL ÑÐ¾Ñ…Ñ€Ð°Ð½ÑÑŽÑ‚ÑÑ Ð² Ð¸Ð¼ÐµÐ½Ð¾Ð²Ð°Ð½Ð½Ð¾Ð¼ Docker volume. Ð”Ð»Ñ Ð¿Ð¾Ð»Ð½Ð¾ÑÑ‚ÑŒÑŽ Ñ‡Ð¸ÑÑ‚Ð¾Ð³Ð¾ Ð·Ð°Ð¿ÑƒÑÐºÐ° Ð¼Ð¾Ð¶Ð½Ð¾ ÑƒÐ´Ð°Ð»Ð¸Ñ‚ÑŒ volume Ð¾Ñ‚Ð´ÐµÐ»ÑŒÐ½Ð¾: `docker compose down --volumes`.

## Ð§Ñ‚Ð¾ Ñ€ÐµÐ°Ð»Ð¸Ð·Ð¾Ð²Ð°Ð½Ð¾

- Ð³Ð¾Ñ€Ð¸Ð·Ð¾Ð½Ñ‚Ð°Ð»ÑŒÐ½Ð°Ñ Ð»ÐµÐ½Ñ‚Ð° Ð¸Ð· 14 Ð´Ð°Ñ‚ Ñ Ð¿ÐµÑ€ÐµÑ…Ð¾Ð´Ð¾Ð¼ Ð¿Ð¾ Ð½ÐµÐ´ÐµÐ»ÑÐ¼;
- Ñ„Ð¸Ð»ÑŒÑ‚Ñ€Ñ‹ Ð¿Ð¾ Ð³Ð¾Ñ€Ð¾Ð´Ñƒ, ÑÑ‚Ð°Ð½Ñ†Ð¸Ð¸, Ñ‚Ñ€ÐµÐ½ÐµÑ€Ñƒ Ð¸ Ñ„Ð¾Ñ€Ð¼Ð°Ñ‚Ñƒ;
- Ð³Ñ€ÑƒÐ¿Ð¿Ð¸Ñ€Ð¾Ð²ÐºÐ° ÐºÐ°Ñ€Ñ‚Ð¾Ñ‡ÐµÐº Ð¿Ð¾ Ñ‚Ñ€ÐµÐ½ÐµÑ€Ð°Ð¼;
- Ð²Ñ€ÐµÐ¼Ñ, ÑƒÑ€Ð¾Ð²ÐµÐ½ÑŒ, Ð°Ð´Ñ€ÐµÑ Ð¸ Ð¸Ð½Ð´Ð¸ÐºÐ°Ñ‚Ð¾Ñ€ Ð·Ð°Ð¿Ð¾Ð»Ð½ÐµÐ½Ð½Ð¾ÑÑ‚Ð¸ Ð³Ñ€ÑƒÐ¿Ð¿Ñ‹;
- Ð¾ÐºÐ½Ð¾ Ð¿Ð¾Ð´Ñ€Ð¾Ð±Ð½Ð¾ÑÑ‚ÐµÐ¹ Ð±ÐµÐ· Ð´ÐµÐ¹ÑÑ‚Ð²Ð¸Ð¹ Ð¾Ð¿Ð»Ð°Ñ‚Ñ‹/Ð·Ð°Ð¿Ð¸ÑÐ¸;
- loading, empty Ð¸ error states;
- Ð°Ð´Ð°Ð¿Ñ‚Ð¸Ð²Ð½Ð°Ñ Ð²ÐµÑ€ÑÐ¸Ñ Ð±ÐµÐ· Ð³Ð¾Ñ€Ð¸Ð·Ð¾Ð½Ñ‚Ð°Ð»ÑŒÐ½Ð¾Ð³Ð¾ Ð¿ÐµÑ€ÐµÐ¿Ð¾Ð»Ð½ÐµÐ½Ð¸Ñ;
- Ð´Ð¾ÑÑ‚ÑƒÐ¿Ð½Ñ‹Ðµ Ð¿Ð¾Ð´Ð¿Ð¸ÑÐ¸ ÑÐ»ÐµÐ¼ÐµÐ½Ñ‚Ð¾Ð², keyboard focus Ð¸ Ð·Ð°ÐºÑ€Ñ‹Ñ‚Ð¸Ðµ Ð¾ÐºÐ½Ð° Ð¿Ð¾ `Escape`;
- PostgreSQL, EF Core migrations Ð¸ Ð¸Ð´ÐµÐ¼Ð¿Ð¾Ñ‚ÐµÐ½Ñ‚Ð½Ñ‹Ð¹ demo seed;
- Problem Details, OpenAPI Ð¸ health-check;
- multi-stage Docker image Ð¸ Ð·Ð°Ð¿ÑƒÑÐº Ð¾Ñ‚ Ð½ÐµÐ¿Ñ€Ð¸Ð²Ð¸Ð»ÐµÐ³Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ð¾Ð³Ð¾ Ð¿Ð¾Ð»ÑŒÐ·Ð¾Ð²Ð°Ñ‚ÐµÐ»Ñ;
- CI Ð´Ð»Ñ backend, frontend Ð¸ Docker-ÑÐ±Ð¾Ñ€ÐºÐ¸.

## ÐÑ€Ñ…Ð¸Ñ‚ÐµÐºÑ‚ÑƒÑ€Ð°

```mermaid
flowchart LR
    Client["React + TypeScript"] -->|HTTP / JSON| Api["ASP.NET Core API"]
    Api --> Application["Application contracts"]
    Application --> Infrastructure["EF Core infrastructure"]
    Infrastructure --> Database[(PostgreSQL)]
```

- `PadelTrialSchedule.Domain` â€” ÑÑƒÑ‰Ð½Ð¾ÑÑ‚Ð¸ Ð¸ Ð¸Ð½Ð²Ð°Ñ€Ð¸Ð°Ð½Ñ‚Ñ‹ Ð¿Ñ€ÐµÐ´Ð¼ÐµÑ‚Ð½Ð¾Ð¹ Ð¾Ð±Ð»Ð°ÑÑ‚Ð¸.
- `PadelTrialSchedule.Application` â€” DTO, Ð·Ð°Ð¿Ñ€Ð¾Ñ Ñ€Ð°ÑÐ¿Ð¸ÑÐ°Ð½Ð¸Ñ Ð¸ Ð°Ð±ÑÑ‚Ñ€Ð°ÐºÑ†Ð¸Ð¸.
- `PadelTrialSchedule.Infrastructure` â€” EF Core, Ð·Ð°Ð¿Ñ€Ð¾ÑÑ‹, Ð¼Ð¸Ð³Ñ€Ð°Ñ†Ð¸Ð¸ Ð¸ seed.
- `PadelTrialSchedule.Api` â€” HTTP API, Ð¾Ð±Ñ€Ð°Ð±Ð¾Ñ‚ÐºÐ° Ð¾ÑˆÐ¸Ð±Ð¾Ðº, health-check Ð¸ Ñ€Ð°Ð·Ð´Ð°Ñ‡Ð° SPA.
- `PadelTrialSchedule.ClientApp` â€” React 19, TypeScript Ð¸ Vite.
- `PadelTrialSchedule.IntegrationTests` â€” API Ñ Ð½Ð°ÑÑ‚Ð¾ÑÑ‰Ð¸Ð¼ PostgreSQL Ñ‡ÐµÑ€ÐµÐ· Testcontainers Ð¸ domain-Ñ‚ÐµÑÑ‚Ñ‹.

Redis, RabbitMQ Ð¸ Elasticsearch Ð½Ðµ Ð´Ð¾Ð±Ð°Ð²Ð»ÐµÐ½Ñ‹ Ð¾ÑÐ¾Ð·Ð½Ð°Ð½Ð½Ð¾: Ð²Ð¸Ð´Ð¶ÐµÑ‚ Ð²Ñ‹Ð¿Ð¾Ð»Ð½ÑÐµÑ‚ Ð½ÐµÐ±Ð¾Ð»ÑŒÑˆÑƒÑŽ read-only Ð²Ñ‹Ð±Ð¾Ñ€ÐºÑƒ, Ð¿Ð¾ÑÑ‚Ð¾Ð¼Ñƒ ÑÑ‚Ð¸ ÐºÐ¾Ð¼Ð¿Ð¾Ð½ÐµÐ½Ñ‚Ñ‹ ÑƒÐ²ÐµÐ»Ð¸Ñ‡Ð¸Ð»Ð¸ Ð±Ñ‹ Ð²Ñ€ÐµÐ¼Ñ ÑÑ‚Ð°Ñ€Ñ‚Ð° Ð¸ ÑÐ»Ð¾Ð¶Ð½Ð¾ÑÑ‚ÑŒ ÑÐºÑÐ¿Ð»ÑƒÐ°Ñ‚Ð°Ñ†Ð¸Ð¸ Ð±ÐµÐ· Ð¿Ñ€Ð°ÐºÑ‚Ð¸Ñ‡ÐµÑÐºÐ¾Ð¹ Ð¿Ð¾Ð»ÑŒÐ·Ñ‹. ÐŸÑ€Ð¸ Ñ€Ð¾ÑÑ‚Ðµ Ð½Ð°Ð³Ñ€ÑƒÐ·ÐºÐ¸ Ðº Ð·Ð°Ð¿Ñ€Ð¾ÑÑƒ Ð¼Ð¾Ð¶Ð½Ð¾ Ð´Ð¾Ð±Ð°Ð²Ð¸Ñ‚ÑŒ distributed cache, Ð½Ðµ Ð¼ÐµÐ½ÑÑ Ð¿ÑƒÐ±Ð»Ð¸Ñ‡Ð½Ñ‹Ð¹ ÐºÐ¾Ð½Ñ‚Ñ€Ð°ÐºÑ‚ API.

## API

`GET /api/v1/trial-schedule`

ÐŸÐ¾Ð´Ð´ÐµÑ€Ð¶Ð¸Ð²Ð°ÐµÐ¼Ñ‹Ðµ query-Ð¿Ð°Ñ€Ð°Ð¼ÐµÑ‚Ñ€Ñ‹:

| ÐŸÐ°Ñ€Ð°Ð¼ÐµÑ‚Ñ€ | Ð¤Ð¾Ñ€Ð¼Ð°Ñ‚ | ÐÐ°Ð·Ð½Ð°Ñ‡ÐµÐ½Ð¸Ðµ |
|---|---|---|
| `dateFrom` | `yyyy-MM-dd` | ÐÐ°Ñ‡Ð°Ð»Ð¾ Ð´Ð¸Ð°Ð¿Ð°Ð·Ð¾Ð½Ð° |
| `dateTo` | `yyyy-MM-dd` | ÐšÐ¾Ð½ÐµÑ† Ð´Ð¸Ð°Ð¿Ð°Ð·Ð¾Ð½Ð°, Ð¼Ð°ÐºÑÐ¸Ð¼ÑƒÐ¼ 32 Ð´Ð½Ñ |
| `cityId` | UUID | Ð“Ð¾Ñ€Ð¾Ð´ |
| `clubId` | UUID | Ð¡Ñ‚Ð°Ð½Ñ†Ð¸Ñ |
| `coachId` | UUID | Ð¢Ñ€ÐµÐ½ÐµÑ€ |
| `type` | `Discovery`, `Fundamentals`, `GameIntroduction` | Ð¤Ð¾Ñ€Ð¼Ð°Ñ‚ |

Ð”Ð¾Ð¿Ð¾Ð»Ð½Ð¸Ñ‚ÐµÐ»ÑŒÐ½Ñ‹Ðµ Ð°Ð´Ñ€ÐµÑÐ°:

- `GET /health` â€” Ð¿Ñ€Ð¾Ð²ÐµÑ€ÐºÐ° Ð¿Ñ€Ð¸Ð»Ð¾Ð¶ÐµÐ½Ð¸Ñ Ð¸ PostgreSQL;
- `GET /openapi/v1.json` â€” OpenAPI-Ð´Ð¾ÐºÑƒÐ¼ÐµÐ½Ñ‚.

## Ð›Ð¾ÐºÐ°Ð»ÑŒÐ½Ð°Ñ Ñ€Ð°Ð·Ñ€Ð°Ð±Ð¾Ñ‚ÐºÐ°

Ð¢Ñ€ÐµÐ±Ð¾Ð²Ð°Ð½Ð¸Ñ: .NET SDK 10, Node.js 20+ Ð¸ Docker.

```bash
docker compose up -d postgres
dotnet run --project src/PadelTrialSchedule.Api
```

Ð’ Ð´Ñ€ÑƒÐ³Ð¾Ð¼ Ñ‚ÐµÑ€Ð¼Ð¸Ð½Ð°Ð»Ðµ:

```bash
cd src/PadelTrialSchedule.ClientApp
npm ci
npm run dev
```

Vite Ð¿Ñ€Ð¾ÐºÑÐ¸Ñ€ÑƒÐµÑ‚ `/api` Ð¸ `/health` Ð½Ð° `http://localhost:5080`.

## ÐŸÑ€Ð¾Ð²ÐµÑ€ÐºÐ¸

Backend build Ð¸ Ñ‚ÐµÑÑ‚Ñ‹:

```bash
dotnet test PadelTrialSchedule.sln --configuration Release
```

Frontend:

```bash
cd src/PadelTrialSchedule.ClientApp
npm run lint
npm run test
npm run build
```

ÐŸÑ€Ð¾Ð²ÐµÑ€ÐºÐ° production-ÑÐ±Ð¾Ñ€ÐºÐ¸:

```bash
docker compose config --quiet
docker compose build
```

Ð˜Ð½Ñ‚ÐµÐ³Ñ€Ð°Ñ†Ð¸Ð¾Ð½Ð½Ñ‹Ðµ Ñ‚ÐµÑÑ‚Ñ‹ Ð°Ð²Ñ‚Ð¾Ð¼Ð°Ñ‚Ð¸Ñ‡ÐµÑÐºÐ¸ Ð¿Ð¾Ð´Ð½Ð¸Ð¼Ð°ÑŽÑ‚ Ð¸Ð·Ð¾Ð»Ð¸Ñ€Ð¾Ð²Ð°Ð½Ð½Ñ‹Ð¹ `postgres:17-alpine`, Ð¿Ñ€Ð¸Ð¼ÐµÐ½ÑÑŽÑ‚ Ð¼Ð¸Ð³Ñ€Ð°Ñ†Ð¸Ð¸, Ð·Ð°Ð¿Ð¾Ð»Ð½ÑÑŽÑ‚ Ð±Ð°Ð·Ñƒ Ð¸ Ð¿Ñ€Ð¾Ð²ÐµÑ€ÑÑŽÑ‚ API Ð±ÐµÐ· Ð·Ð°Ð²Ð¸ÑÐ¸Ð¼Ð¾ÑÑ‚Ð¸ Ð¾Ñ‚ Ð»Ð¾ÐºÐ°Ð»ÑŒÐ½Ð¾Ð¹ Ð‘Ð”.

