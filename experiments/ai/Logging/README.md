# Logging in .NET Core — Technical Lab Notebook

## 🎯 The Core Question

**Abstraction & injection:** How `ILogger<T>` / `ILoggerFactory` work, DI registration, and why we log via interfaces.

**Configuration & routing:** How log levels, categories, and providers are configured and how events flow to sinks.

**Goal:** Explore logging thoroughly — from understanding and configuring built-in features to implementing third-party providers.

---

## 🛠 Project Structure

- **Isolation Strategy:** Single project, **folder/namespace per variation**; variations coexist side-by-side (no merging).
- **Core Abstractions:** `ILogger`, `ILogger<T>`, `ILoggerFactory`; host-based logging setup via `ConfigureLogging` and `appsettings.json` **Logging** section.

---

## 🔬 Lab Variations

### Variation 1: Console + configuration

- **Location:** [`Program.cs`](Program.cs), [`Var1_ConsoleConfiguration/`](Var1_ConsoleConfiguration/) (e.g. [`DemoService.cs`](Var1_ConsoleConfiguration/DemoService.cs)), [`appsettings.json`](appsettings.json).

- **The Mechanic:** The host (`Host.CreateDefaultBuilder`) wires **configuration** (including `appsettings.json`) and **logging**. `ConfigureLogging` registers **providers**; we use `ClearProviders()` then `AddJsonConsole()` so every log event goes to the console as **JSON**. The **category** for `ILogger<T>` is the full type name of `T`; the runtime matches `Logging:LogLevel` keys by prefix (longest match wins). So a namespace-level key (e.g. `ConceptLab.Logging.Var1_ConsoleConfiguration: Debug`) applies to all loggers in that namespace, and a more specific key (e.g. `...ExplicitCategory: Trace`) applies when you create a logger with that category via `ILoggerFactory.CreateLogger("...")`.

- **Implementation Note:** Variation 1 lives in namespace `ConceptLab.Logging.Var1_ConsoleConfiguration` and a dedicated folder; the single `Program.cs` runs the selected variation via a menu. Config is one shared `appsettings.json` with a **Logging:LogLevel** section; no per-variation config files.

- **The Outcome:** Running `dotnet run` and choosing **1** prints **JSON lines** to stdout. For `ILogger<DemoService>` you see **Debug** and above (Trace filtered by config); for the factory-created logger with category `...ExplicitCategory` you see **Trace** and above. Example line:

```json
{"EventId":0,"LogLevel":"Debug","Category":"ConceptLab.Logging.Var1_ConsoleConfiguration.DemoService","Message":"Debug from ILogger<DemoService>","State":{"{OriginalFormat}":"Debug from ILogger<DemoService>"}}
```

**Config snippet** that drives it:

```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "ConceptLab.Logging.Var1_ConsoleConfiguration": "Debug",
    "ConceptLab.Logging.Var1_ConsoleConfiguration.ExplicitCategory": "Trace"
  }
}
```

---

### The Insight Engine (Trade-offs) — Variation 1

- **Pros:** Single abstraction (`ILogger`/`ILoggerFactory`); **config-driven levels** without code changes; **category = type name** keeps filtering predictable; JSON console gives **structured output** for later contrast with Serilog.
- **Cons:** Console app needs **explicit** `Microsoft.Extensions.Configuration.Json` for `appsettings.json` to load with `CreateDefaultBuilder`; one provider only (no multi-sink comparison yet).
- **The "When" Rule:** Use this setup when you want **one console sink**, **config-based level and category filtering**, and **type-named categories** with optional explicit categories via `ILoggerFactory`.

---

### Variation 2: Console + Debug (multiple providers)

- **Location:** [`Program.cs`](Program.cs), [`Var2_MultipleProviders/`](Var2_MultipleProviders/) (e.g. [`DemoService.cs`](Var2_MultipleProviders/DemoService.cs)).

- **The Mechanic:** Same host and `ConfigureLogging`; we add **two** providers: `AddJsonConsole()` and `AddDebug()`. The **same** `Logging:LogLevel` filter applies to both—the pipeline filters once, then forwards the same events to every provider. One log call produces output in both the console (JSON) and, when attached, the IDE Debug/Output window.

- **Implementation Note:** Variation 2 lives in namespace `ConceptLab.Logging.Var2_MultipleProviders` and a dedicated folder; same `appsettings.json`; no per-provider level config.

- **The Outcome:** Choose **2** at the menu; JSON lines appear in the terminal and the same messages go to the Debug provider (visible in the IDE Debug/Output window when debugging).

---

### The Insight Engine (Trade-offs) — Variation 2

- **Pros:** Multiple sinks with one config; same abstraction; good for “console + debugger” during development.
- **Cons:** No per-provider minimum level in default config; Debug output only visible when debugger is attached.
- **The "When" Rule:** Use when you want **console and debugger output** with the same filter and no extra config.

**What Var 2 unlocks:** One log call goes to **both** the terminal and the IDE Debug/Output window when debugging. Same `Logging:LogLevel` applies to all providers; adding a sink is one line in host setup (`AddDebug()`). No changes to app logging code—the pipeline broadcasts the same filtered events to every provider.

---

### Contrast: Var 1 → Var 2

| Aspect | Var 1 | Var 2 |
|--------|--------|--------|
| **Sinks** | Console only | Console + Debug (when attached) |
| **Config** | One `Logging:LogLevel` | Same—single filter for all providers |
| **Cost** | Minimal | One extra package + one `AddDebug()` |
| **Unlock** | Abstraction + config-driven levels | **Multiple destinations** for the same log stream without touching call sites |

In Var 1 we learned the abstraction and config. In Var 2 we didn't fix Var 1—we **unlocked** routing the same events to more than one sink. That pattern (one pipeline, many providers) carries through to third-party providers (e.g. Serilog in Var 3).

---

## Maintenance & Progress

- **Plan:** See [Plan.md](Plan.md) for the full roadmap and variation status.
- **Progress:** Variation 1 (Console + configuration) and Variation 2 (multiple built-in providers) are implemented and documented; next is Variation 3 (Serilog).
