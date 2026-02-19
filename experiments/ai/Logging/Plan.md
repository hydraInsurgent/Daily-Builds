# Logging in .NET Core — Implementation Plan

**Overall Progress:** ~15%

## TLDR

**Objective:** Explore logging in .NET Core thoroughly: the abstraction (`ILogger` / `ILoggerFactory`), configuration (levels, categories, `appsettings.json`), built-in and third-party providers (Serilog), scopes (incremental), and structured logging contrast. Single project with folders/namespaces per variation.

**Scope Boundaries:**

- **In-Scope:** `ILogger`/DI, Console + Debug providers, logging config, Serilog as third-party provider, scopes (incremental), structured logging comparison.
- **Out-of-Scope:** Full app logic, OpenTelemetry/distributed tracing, external sinks (Seq, App Insights, Elasticsearch), .NET Framework.

**All Planned Variations:**

- [ ] **Var 1:** Console + configuration — ILogger, DI, minimum level and category via config.
- [ ] **Var 2:** Multiple built-in providers (Console + Debug) — how providers coexist and are configured.
- [ ] **Var 3:** Serilog as provider — plug-in to ILogger, structured logging, comparison.
- [ ] **Var 4:** Scopes (incremental) — BeginScope, request/correlation context.
- [ ] **Var 5:** Failure / anti-pattern — intentional misuse; symptom log.
- [ ] **Var 6:** Structured logging (built-in vs Serilog) — contrast API and output.

## Success Criteria

- [ ] Confident with abstraction, configuration, and multiple providers.
- [ ] Confident adding and configuring Serilog and explaining trade-offs.
- [ ] Confident with scopes (incremental) and structured logging contrast.

## Critical Decisions

- **Third-party provider:** Serilog first — learn one provider in depth.
- **Scopes:** In-scope, introduced incrementally in a dedicated variation.
- **Isolation:** Single project, folders/namespaces per variation; variations coexist.

## Tasks

### Phase 1: Framing

- [x] 🟩 **Step 1: Concept Framing**
  - [x] 🟩 Define Question & Success Criteria
  - [x] 🟩 Finalize Variation List & Isolation Strategy

### Phase 2: Exploration Loop

- **Standard:** /explore → /execute → /contrast → /document
- **Failure steps:** /break → /document
- **Contrast-only steps:** /contrast → /document

---

- [x] 🟩 **Step 2: Console + configuration**
  - [x] `ILogger<T>` and `ILoggerFactory`
  - [x] Registering logging in DI (`AddLogging`, host builder)
  - [x] Console provider
  - [x] `appsettings.json` "Logging" section; default minimum level and category (namespace) overrides
  - [x] Log level enum and extension methods (`LogInformation`, `LogWarning`, `LogError`)
  - [x] Where output appears (console)
  - [x] Isolation: folder/namespace for this variation; minimal host + one service that logs

- [ ] 🟥 **Step 3: Multiple built-in providers (Console + Debug)**
  - [ ] Adding both Console and Debug providers
  - [ ] How `Logging:LogLevel` applies to each provider
  - [ ] Filtering and routing to multiple sinks
  - [ ] When to use Console vs Debug (dev vs debugger)
  - [ ] Configuration structure for multiple providers
  - [ ] Isolation: separate folder/namespace; build on Step 2 without merging

- [ ] 🟥 **Step 4: Serilog as provider**
  - [ ] Serilog packages and `UseSerilog()`
  - [ ] Replacing or coexisting with default pipeline
  - [ ] Structured properties and message templates
  - [ ] Configuring sinks (e.g. Console, file)
  - [ ] Code vs config setup
  - [ ] Why Serilog (enrichers, structured output, sink ecosystem)
  - [ ] Isolation: separate folder/namespace; same `ILogger` abstraction, different provider

- [ ] 🟥 **Step 5: Scopes (incremental)**
  - [ ] `BeginScope` and `IDisposable`
  - [ ] What scopes represent (key-value or state)
  - [ ] How Console/Debug and Serilog display scope (indentation, properties)
  - [ ] Request/correlation ID pattern
  - [ ] Nesting scopes
  - [ ] Isolation: separate folder/namespace; incremental on top of prior variations

- [ ] 🟥 **Step 6: Failure / anti-pattern**
  - [ ] Anti-pattern: static logger without DI
  - [ ] Anti-pattern: everything logged as Information
  - [ ] Anti-pattern: blocking in logging path
  - [ ] Anti-pattern: logging PII or exceptions poorly
  - [ ] How each failure manifests
  - [ ] Symptom log — what a developer would see (no logs, noise, hangs, security)

- [ ] 🟥 **Step 7: Structured logging (built-in vs Serilog)**
  - [ ] Built-in: message template, template parameters, `LoggerMessage` source generator if relevant
  - [ ] Serilog: structured properties, destructuring
  - [ ] Contrast: output format, queryability, performance

### Phase 3: Lab Wrap-up

- [ ] 🟥 **Step 8: Final Review**
  - [ ] Technical audit of all variations (/review)
  - [ ] Design implications, coupling, lifetime
  - [ ] Finalize README as "Technical Lab Notebook"

---

## Future Exploration (Later Labs)

Out-of-scope for this lab; capture for later:

- **Distributed tracing / OpenTelemetry** — separate concept lab.
- **External sinks** — Seq, Application Insights, Elasticsearch (integration and configuration).
- **Full application context** — logging across a larger app with real business logic.
- **.NET Framework** — logging in non–.NET Core runtimes (if ever needed).
