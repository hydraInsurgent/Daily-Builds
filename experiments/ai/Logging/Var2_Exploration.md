# Variation 2: Multiple Built-in Providers (Console + Debug) — Exploration Blueprint

**Status:** Executed (Variation 2 implemented and verified)

---

## 1. Technical Clarification

### Sub-tasks (from Plan.md)

- Adding both Console and Debug providers
- How `Logging:LogLevel` applies to each provider
- Filtering and routing to multiple sinks
- When to use Console vs Debug (dev vs debugger)
- Configuration structure for multiple providers
- Isolation: separate folder/namespace; build on Var 1 without merging

### The Core Question

**How do multiple logging providers coexist, and how does configuration apply when more than one sink is registered?** We want to see that a single `ILogger` call produces output in **both** the console and the Debug output window (when running under a debugger), and that the **same** `Logging:LogLevel` filter applies to both—i.e. the pipeline filters once, then each provider receives the same set of events.

### Contrast with Variation 1

- **Var 1:** One provider (JSON Console); `ClearProviders()` then `AddJsonConsole()`; config drives level/category; output only in console.
- **Var 2:** **Two** providers (Console + Debug); add both; **same** `Logging:LogLevel` applies to both; output in console **and** (when attached) in the debugger’s Output window. So we’re adding a second sink and observing “one log call → two outputs.”

### Mechanism

- **Same host** as Var 1: `Host.CreateDefaultBuilder()` and `ConfigureLogging`. We **add** both `AddJsonConsole()` and `AddDebug()`.
- **Important:** In the default Microsoft.Extensions.Logging model, **there is no per-provider minimum level** in `appsettings.json`. The `Logging:LogLevel` section is global: the logging pipeline filters by level/category once, then forwards the same events to every provider.

---

## 2. Isolation Strategy

- **Namespacing:** `ConceptLab.Logging.Var2_MultipleProviders`
- **File isolation:**
  - New folder: `Var2_MultipleProviders/` with its own demo service.
  - **Entry point:** Variation selector in `Program.cs` (menu or env `LOGGING_VAR=2`). Var 1 and Var 2 code stay in separate folders/namespaces; only the runner in `Program.cs` branches.
- **Configuration:** Reuse the same `appsettings.json` and same `Logging:LogLevel` section.

---

## 3. Minimalist Path & Choices

**Minimalist implementation:**

1. **Variation selector:** In `Program.cs`, read from env (e.g. `LOGGING_VAR`) or menu. When `"2"`, build a host configured for Var 2 and run the Var 2 demo; when `"1"`, run Var 1.
2. **Var 2 host:** `ConfigureLogging(builder => { builder.ClearProviders(); builder.AddJsonConsole(); builder.AddDebug(); })`.
3. **Var 2 demo:** New service in `Var2_MultipleProviders/` that takes `ILogger<T>` and logs a few lines (e.g. Information, Warning).
4. **Config:** Unchanged; existing `Logging:LogLevel` applies to both providers.

**Choices applied:** AddJsonConsole() kept; new Var 2 demo in `Var2_MultipleProviders/`; Debug visibility via README/comment only.

---

## 4. Plan & Success Criteria

- **Success criteria (Plan.md):** “Confident with abstraction, configuration, and **multiple providers**.” Variation 2 directly addresses “multiple providers” and “filtering and routing to multiple sinks.”
- **Dependencies:** `Microsoft.Extensions.Logging.Debug`.

---

## 5. Summary

| Topic | Choice |
|-------|--------|
| **Core mechanic** | Two providers (Console + Debug); same `Logging:LogLevel`; one log call → two sinks. |
| **Namespace** | `ConceptLab.Logging.Var2_MultipleProviders` |
| **Entry** | Variation selector in `Program.cs` (menu or `LOGGING_VAR=2`). |
| **Config** | Same `appsettings.json`; no per-provider levels. |
| **New package** | `Microsoft.Extensions.Logging.Debug` |

---

## Verification

- **Var 1:** `dotnet run` → choose **1** — JSON output (Var 1 demo).
- **Var 2:** `dotnet run` → choose **2**, or `LOGGING_VAR=2 dotnet run` (PowerShell: `$env:LOGGING_VAR='2'; dotnet run`) — two JSON lines from Console; when running under a debugger, the same two messages also appear in the IDE Debug/Output window.
