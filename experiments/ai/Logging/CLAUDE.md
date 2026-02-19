# Project Instructions for Claude (v2.1 - Full Framework)

## 🎯 About This Project: Concept Labs

Each repository represents a focused exploration of a single primary engineering concept (e.g., Middleware, Auth, Async). This is **not** a production project; it is a **Technical Lab Notebook**. We optimize for clarity, trade-offs, and system understanding—not feature completion.

**Who I Am:** A developer strengthening fundamentals through structured exploration. I value **Insight > Polish** and **Comparison > Refactoring**.

---

# 📜 Core Philosophy & Critical Rules

1. **Never auto-fix:** Report issues first. Wait for explicit approval before modifying files.
2. **Preserve Variation Coexistence:** Do not remove or merge previous approaches. Multiple competing implementations **must** coexist side-by-side.
3. **Explain Reasoning:** Always narrate what you are doing. Call out trade-offs and framework mechanics.
4. **Isolation Over Modification:** Add new variations alongside existing ones. Avoid rewriting earlier implementations.
5. **No Silent Scope Expansion:** New conceptual directions (Adjacent Concepts) require explicit framing via `/concept`. 
6. **Plan.md Immutability**:** Once the Plan.md is generated at the end of the /concept phase, it is frozen. No new variations or major scope changes can be added to the current plan.
7. **Escalation**: If a new variation or adjacent concept is discovered that needs implementation, /concept command must be run again to interrogate, suggest, and re-frame the new scope into an updated or new Plan.md.
---

# 🏗 Phase 1 — Concept Framing (Run Once Per Concept)

### Command: `/concept`

Establish the learning contract. Claude must make intelligent assumptions but **must perform a "Stop-Check"** before implementation.

**Responsibilities:**

* Define the **Core Question** (The "Why").
* Define explicit **Scope Boundaries** (In-scope vs. Out-of-scope).
* Identify initial **Known Variations** to be explored.
* **Stop-Check:** List all architectural assumptions for user confirmation.
* Confirm **Solution Structure** (Namespace isolation vs. Multi-project).
* Create Plan.md: Generate a structured roadmap file in the root directory listing the sequence of variations and /break scenarios to be executed.

**Constraint:** No code generation or refactoring occurs in this phase.

---

# 🔬 Phase 2 — Variation Exploration Loop (Repeatable)

### 1. `/explore` (Clarification)

Define the variation before touching code.

* Identify the specific question this variation answers.
* Explain how it differs from existing variations.
* **Isolation Strategy:** Confirm how this will be separated (e.g., `v2/` folder, `FeatureName` namespace, or separate project).

### 2. `/execute` (Implementation)

Implement the variation in isolation.

* Narrate decisions and trade-offs during implementation.
* **Strict Rule:** Do not refactor unrelated areas or collapse multiple approaches into one.

### 3. `/break` (The Failure Lab)

Intentionally implement an "Anti-Pattern" or common mistake related to the concept.

* Demonstrate the failure (e.g., a deadlock, a security hole, or a performance bottleneck).
* Provide a "Symptom Log" describing how a developer would "see" this failure in a real system.

### 4. `/contrast` (The Insight Engine)

Build intuition through structured comparison. **No code changes occur here.**
Explicitly identify:

* **What became simpler?** (DevEx, LoC, Readability).
* **What became more complex?** (Configuration, Cognitive Load).
* **The "When" Rule:** When does this approach make sense? When is it a "smell"?

### 5. `/review` (The Audit)

Provide a structured analysis of the current state without fixing anything.

* Highlight: Design implications, hidden coupling, state/lifetime concerns, or misuse of framework mechanics.

### 6. `/document` (The Artifact)

Update the `README.md` (The primary navigation surface).

**Mandatory README Structure per Variation:**

* **Variation Entry:** Link to relevant code locations.
* **Mechanic:** How the syntax/framework works here.
* **Architectural Impact:** How this affects the broader system.
* **The Trade-off:** High-level summary of what was gained vs. lost.

---

# 💻 Workflow & Commands Summary

| Command | Purpose | Output |
| --- | --- | --- |
| `/concept` | Frame the Lab | Framing Doc + Assumptions |
| `/explore` | Deep dive into a variant | Isolation Strategy |
| `/execute` | Code the variant | Isolated Source Code |
| `/break` | Show the anti-pattern | "Broken" code + Symptom Log |
| `/contrast` | Compare variations | Trade-off Matrix |
| `/review` | Technical Audit | Potential Issues List |
| `/document` | Update README | Technical Insights |
| `/learning-opportunity` | Deep Dive | Multiple abstraction levels |
| `/package-review` | Dependency analysis | Library-specific trade-offs |

---

# 🛠 Git & Organization

* **Structure:** Code clarity > architectural perfection. Use separate controllers, folders, or projects.
* **Commits:** Must reflect learning intent (e.g., `Contrast console vs serilog providers`).
* **Adjacent Concepts:** If a concept requires a new layer (e.g., adding OpenTelemetry to a Logging lab), it lives in its own project and requires a new `/concept` framing.

---

**Note to Claude:** When a command is invoked, read the corresponding instruction file in `./.claude/commands/[command].md` to ensure the output meets the required structure.