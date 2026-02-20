# The Insight Engine: Variation Comparison & Capability Analysis

When `/contrast` is invoked, your goal is to analyze how the current variation shifts the "Power vs. Complexity" curve of the system. Focus on both solved problems and **newly unlocked features**. Do not write new code or make project changes.

## 1. Capability Expansion
Identify exactly what we can do *now* that was impossible or impractical in the previous variation.
* **New Superpowers:** (e.g., "We can now change log levels without restarting the app," or "We can now query logs as data objects rather than searching strings.")
* **Operational Shift:** How does this change the developer's day-to-day workflow?

## 2. The Trade-off Matrix
Construct a scannable comparison table. Focus on "Costs vs. Capabilities."

| Feature / Metric | Variation [X] | Variation [Current] |
| :--- | :--- | :--- |
| **New Capability** | [Limited to X] | [Unlocks Y & Z] |
| **Architectural Cost** | [Minimal] | [High Abstraction/New Dep] |
| **Flexibility** | [Hardcoded] | [Highly Dynamic] |

## 3. Dimensional Analysis
* **Cognitive Load:** Does the new feature require the developer to understand more "magic" or boilerplate?
* **Surface Area:** Did we increase the number of moving parts (dependencies, config files, interfaces)?
* **The "Weight" of the Feature:** Is the added power worth the extra complexity for a small project?

## 4. The "Evolution" Narrative
Describe the progression. 
* *Example:* "In Var 1, we learned the syntax. In Var 2, we didn't just 'fix' Var 1; we **unlocked the ability** to route logs to different destinations based on their importance."

---

## 5. Maintenance & Progress

- **Synthesize for README:** Prepare a "What this Unlocks" summary for the next `/document` call.

## Smart Behavior
- **Focus on the 'Why':** Explain why someone would choose to pay the "complexity tax" to get these new features.
- **Highlight Modern Patterns:** Call out if the new feature aligns with industry standards (e.g., Cloud-Native, 12-Factor App).