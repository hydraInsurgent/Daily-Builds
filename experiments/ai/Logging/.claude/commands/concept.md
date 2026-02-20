# Concept Framing Stage: Interrogation & Planning

When `/concept` is invoked, you must conduct a targeted interview to finalize the lab scope. Do not generate `Plan.md` until the framing is explicitly agreed upon.

## 1. The Interrogation Protocol
For each of the following pillars, **ask a question** and provide **2-3 categorized suggestions**:

* **Core Question:** What specific behavior/mechanic is being explored?
* **Success Criteria:** What defines "Concept Mastered"?
* Define explicit **Scope Boundaries** (In-scope vs. Out-of-scope).
* **Variations:** Suggest a list of variations (e.g., different types that exist, different difficulty levels such as Basic, Advanced, Failure, Adjacent).
* **Isolation Strategy:** How to separate the code (Folders vs. Projects).

## 2. The Agreement Gate
Present a consolidated "Lab Contract" for final sign-off.
* **DO NOT** generate `Plan.md` yet.
* Explicitly ask: "Does this summary capture your intent, and are these the variations we want to track?"

## 3. Plan.md Generation
Only after explicit approval, generate the `Plan.md`. Ensure all identified variations are listed in the TLDR for full visibility.

---

## Plan.md Template

# [Concept Name] Implementation Plan

**Overall Progress:** `0%`

## TLDR
**Objective:** Short summary of what we're building and why.

**Scope Boundaries:**
- **In-Scope:** [Agreed boundaries]
- **Out-of-Scope:** [Specifically excluded topics]

**All Planned Variations:**
- [ ] **Var 1:** [Brief Description]
- [ ] **Var 2:** [Brief Description]
- [ ] **Var 3:** [Brief Description] (Failure Mode)
- [ ] **Var 4:** [Brief Description] (Adjacent/Advanced)

## Success Criteria
- [ ] Agreed Criterion 1
- [ ] Agreed Criterion 2

## Critical Decisions
- Decision 1: [choice] - [brief rationale]

## Tasks

### Phase 1: Framing
- [ ] 🟩 **Concept Framing**
  - [ ] 🟩 Define Question & Success Criteria
  - [ ] 🟩 Finalize Variation List & Isolation Strategy

### Phase 2: Exploration Loop

- **Standard variations:** /explore → /execute → /contrast → /document
- **Failure variations:** /break → /document
- **Contrast-only:** /contrast → /document

---

- [ ] 🟥 **Var 1: [Name of Var 1]**
  - [ ] [Thing to explore or implement for this variation — e.g. core abstraction, config, one provider]
  - [ ] [Another concrete sub-task]
  - [ ] Isolation: folder/namespace for this variation; [minimal scope]

- [ ] 🟥 **Var 2: [Name of Var 2]**
  - [ ] [Thing to explore — e.g. adding a second provider, how config applies]
  - [ ] [Sub-task]
  - [ ] Isolation: separate folder/namespace; build on Var 1 without merging

- [ ] 🟥 **Var 3: [Name of Var 3 — Failure / anti-pattern]**
  - [ ] Anti-pattern or intentional misuse to demonstrate
  - [ ] How the failure manifests
  - [ ] Symptom log — what a developer would see

- [ ] 🟥 **Var 4: [Name of Var 4 — Advanced or contrast]**
  - [ ] [Thing to explore — e.g. third-party provider, advanced feature]
  - [ ] [Sub-task]
  - [ ] Isolation: separate folder/namespace; [relationship to prior variations]

Note: Adjust the number of variations and their sub-tasks to match the agreed-upon list. Each variation’s bullets describe **what to explore or implement**, not the workflow (explore/execute/contrast/document are applied per the Standard/Failure/Contrast-only rules above).

### Phase 3: Lab Wrap-up
- [ ] 🟥 **Final Review**
  - [ ] 🟥 Technical audit of all variations (/review)
  - [ ] 🟥 Finalize README as "Technical Lab Notebook"