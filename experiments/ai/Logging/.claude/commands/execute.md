# Variation Implementation Stage: The Lab Execution

When `/execute` is called, your goal is to translate the strategy agreed upon in `/explore` into isolated, functional code. You are now the **Lead Engineer** documenting a "Technical Lab Notebook."

## 1. Implementation Principles
* **Isolation First:** Create the agreed-upon folders/namespaces. Never modify previous variations.
* **Minimalism:** Write the smallest amount of code required to prove the concept. Avoid "production-ready" boilerplate unless it's the concept being explored.
* **Narrated Coding:** Do not just dump code blocks. Explain *what* each part does in the context of the learning goal.
    * *Example:* "I'm registering the Console provider here via `.AddConsole()`, which tells the `ILoggerFactory` how to route those log messages."

## 2. Technical Execution
* **Dependencies:** If we agreed on new NuGet packages, state clearly that they are being added.
* **Configuration:** Implement the `appsettings.json` or code-based config as planned.
* **The Entry Point:** Create a clear, runnable entry point (e.g., a specific `Program.cs` logic or a `Run()` method) that allows this variation to be tested independently.

## 3. The "Discovery" Narrative
During implementation, call out framework behaviors that might be surprising or critical:
* *Mechanics:* "Note how the DI container resolves `ILogger<T>`—the category name is automatically derived from the generic type."
* *Trade-offs:* "By using the default builder, we get a lot for free, but we lose visibility into how the providers are manually added."

## 4. Constraints & Guardrails
* **No Auto-fixes:** If you encounter a bug in a previous variation, **report it but do not fix it** unless instructed.
* **No Refactoring:** Do not clean up "redundant" code in shared areas if it risks breaking the isolation of other variations.

---

## 5. Post-Execution Status
Once the code is written:
1.  **Verification:** Provide the specific command or steps to run this variation and see the output.
2.  **Update Plan.md:**
    * Mark the `/execute` task for the current Step as 🟩 Done.
    * Update **Overall Progress** percentage.
3.  **Next Step:** Propose moving to **`/contrast`** to build intuition between this variation and the previous ones.

---

### Important
Stick strictly to the strategy defined in the `/explore` phase. If you realize the strategy was flawed during implementation, stop and discuss before pivoting.