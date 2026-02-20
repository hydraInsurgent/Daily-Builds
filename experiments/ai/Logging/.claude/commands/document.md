# Documentation Stage: The Lab Notebook

When `/document` is called, your goal is to update the root `README.md`. If the file does not exist, initialize it first using the "Lab Notebook" template below.

## 1. Initialization (If README.md is missing)
If this is the first time documenting, create the `README.md` with this structure:

# [Concept Name] — Technical Lab Notebook

## 🎯 The Core Question
[Insert the "Why" from the /concept phase]

## 🛠 Project Structure
- **Isolation Strategy:** [e.g., Folder-per-variation]
- **Core Abstractions:** [e.g., ILogger, ILoggerFactory]

## 🔬 Lab Variations
[This section will be populated incrementally by the Variation Entries below]

---

## 2. Variation Entry (Mandatory Structure)
For every completed variation, append a new entry to the **Lab Variations** section:

### [Variation Name]
- **Location:** `[Link to folder/files]`
- **The Mechanic:** Explain the underlying framework logic in 2-3 sentences.
- **Implementation Note:** How we isolated this variation specifically.
- **The Outcome:** Describe the observable behavior (Console output, debugger state, etc.).

## 3. The Insight Engine (Trade-offs)
Distill the learning into a scannable comparison:
- **Pros:** What became simpler or more powerful?
- **Cons:** What was sacrificed (Performance, readability, config complexity)?
- **The "When" Rule:** Write a one-sentence rule for when to use this approach.

## 4. Maintenance & Progress
- **Table of Contents:** If the lab is large, add/update links at the top for navigation.
- **Plan.md Update:** - Mark the `/document` task for the current Step as 🟩 Done.
  - Recalculate and update the **Overall Progress** percentage in `Plan.md`.

---

## Smart Behavior
- **Scannability:** Use bold text for key terms.
- **Mini-Snippets:** Use high-impact code snippets (max 10 lines) to show the "Aha!" moment.
- **Tone:** Technical, objective, and insightful—writing for "Future You."

## Important
If the README already exists, **do not overwrite it**. Append the new variation to the end of the "Lab Variations" section to maintain a chronological record of the lab.

## Ask if Uncertain
If you're unsure about intent behind a change or user-facing impact, **ask the user** - don't guess.
