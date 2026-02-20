# Variation 1: Console + Configuration — Exploration Blueprint

**Status:** Executed (Variation 1 implemented and verified)

---

## Decisions (from /explore)

| Topic | Choice | Note |
|-------|--------|------|
| **Output format** | JSON console | Use `AddJsonConsole()` so we see structured output early; contrast with Serilog later. |
| **Entry point** | Single `Program.cs` | Menu to select variation; add more options as variations are added. |
| **ILogger usage** | Both | Demo service uses `ILogger<T>`; also show one explicit `ILoggerFactory` usage (e.g. create logger by category). |
| **Plan tracking** | Separate file | Exploration outcomes live here; `Plan.md` is not updated with in-progress or decisions. |

---

## Core question

How does .NET get from `ILogger<T>` in app code to lines in the console, and how is that controlled by config?  
Focus: **abstraction** (ILogger/ILoggerFactory) and **configuration** (Logging section, levels, categories).

---

## Mechanism

- **Host:** `Host.CreateDefaultBuilder()` with `ConfigureLogging(builder => builder.AddJsonConsole())`.
- **Config:** Single `appsettings.json` with `Logging` section (default level + category overrides).
- **Document:** Short note in README or comments: Host → ILoggerFactory → Console provider.

---

## Isolation

- **Namespace:** `ConceptLab.Logging.Var1_ConsoleConfiguration`
- **Structure:** One .NET console app; Variation 1 in folder `Var1_ConsoleConfiguration/` with:
  - Host setup (in root `Program.cs`) that runs the selected variation (menu or `LOGGING_VAR`).
  - Demo service: `IDemoService` + `DemoService` with `ILogger<DemoService>`; plus one `ILoggerFactory` usage (e.g. second logger by category).
- **Config:** One `appsettings.json` at project root; no per-variation config yet.

---

## Minimalist implementation checklist

- [x] Create .NET console app (e.g. .NET 8; project uses net10.0).
- [x] Folder/namespace `Var1_ConsoleConfiguration` with demo service.
- [x] Host: `CreateDefaultBuilder`, `ConfigureLogging` → `AddJsonConsole()`, load `appsettings.json`.
- [x] `appsettings.json`: `Logging:LogLevel:Default` + at least one category override (e.g. namespace = `Debug`).
- [x] Demo service: logs at Trace/Debug/Information/Warning/Error; one `ILoggerFactory`-created logger.
- [x] No Serilog, no scopes, no Debug provider — Console + config only.

## Verification

From repo root:

```bash
dotnet build
dotnet run
```

Choose **1** at the menu. Expected: JSON log lines on stdout; `ILogger<DemoService>` shows Debug and above (category override); `ILoggerFactory.CreateLogger("...ExplicitCategory")` shows Trace and above.

---

## Success criteria (Plan.md)

Variation 1 satisfies: ILogger/ILoggerFactory, DI, Console provider, appsettings Logging, levels, categories, extension methods, where output appears, isolation.  
“Multiple providers” is addressed in Variation 2.

---

## Dependencies

- `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.Logging.Console` (as agreed).
- `Microsoft.Extensions.Configuration.Json` added so `CreateDefaultBuilder` loads `appsettings.json` in a console app (not pulled in by the host package alone).
