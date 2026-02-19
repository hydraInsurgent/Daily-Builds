# Logging in .NET Core — Lab Contract (Final Review)

**Status:** Approved. `Plan.md` generated; this contract is frozen for the current lab.

---

## 1. Core Question

**Both** abstraction/mechanism and configuration/routing:

- **Abstraction & injection:** How `ILogger<T>` / `ILoggerFactory` work, DI registration, and why we log via interfaces.
- **Configuration & routing:** How log levels, categories, and providers are configured and how events flow to sinks.

**Goal:** Explore logging thoroughly — from understanding and configuring built-in features to implementing third-party providers.

---

## 2. Success Criteria

- **Confident** in the full set: abstraction, configuration, multiple providers, third-party (Serilog), and scopes (incremental).
- Able to add and configure logging in a .NET Core project and explain trade-offs.

---

## 3. Scope Boundaries

### In-Scope

- `ILogger` / `ILogger<T>` / `ILoggerFactory` usage and DI.
- Built-in providers: **Console**, **Debug**.
- Configuration: `Logging` in `appsettings.json`, minimum level, category overrides.
- **Serilog** as the third-party provider (plug-in, structured logging, comparison).
- **Scopes** (e.g. `BeginScope` for request/correlation) — introduced **incrementally** so they build on prior variations.
- Structured logging contrast: built-in vs Serilog where useful.

### Out-of-Scope (this lab)

- Full application or business logic beyond minimal host + demo services.
- Distributed tracing / OpenTelemetry.
- External sinks: Seq, Application Insights, Elasticsearch (mentioned only as “where logs can go”).
- .NET Framework or other runtimes; focus is **.NET Core / .NET 5+** and generic host.

---

## 4. Variations to Track

| # | Variation | Type |
|---|------------|------|
| 1 | Console + configuration | Basic |
| 2 | Multiple built-in providers (Console + Debug) | Basic |
| 3 | Serilog as provider | Advanced |
| 4 | Scopes (incremental) | Advanced |
| 5 | Failure / anti-pattern | Failure |
| 6 | Structured logging (built-in vs Serilog) | Contrast |

---

## 5. Isolation Strategy

- **Option A:** Single project, **folders/namespaces per variation**.
- Minimal “runner” (e.g. one `Program.cs` or small menu) to execute demos.
- No merging of variations; they coexist side-by-side.

---

## 6. Critical Decisions

| Decision | Choice | Rationale |
|----------|--------|------------|
| Third-party provider | Serilog first | Explicit preference; learn one provider in depth. |
| Scopes | In-scope, incremental | Add scopes in a later variation so they build on prior work. |
| Out-of-scope items | Document for later | Listed in Plan.md under “Future exploration” for later labs. |

---

## 7. Future Exploration (Out-of-Scope for This Lab)

To be listed at the bottom of `Plan.md` for later exploration:

- **Distributed tracing / OpenTelemetry** — separate concept lab.
- **External sinks** — Seq, Application Insights, Elasticsearch (integration and configuration).
- **Full application context** — logging across a larger app with real business logic.
- **.NET Framework** — logging in non–.NET Core runtimes (if ever needed).

---

**If this contract looks correct, confirm and `Plan.md` will be generated with the agreed variations and the Future exploration section.**
