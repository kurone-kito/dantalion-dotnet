# Guidelines for GitHub Copilot

## Project overview

dantalion-dotnet is the .NET port of dantalion: a CLI app and NuGet
library that calculates personality from a birthday. Its source is
intended to be reused for a future VPM (UPM) package for Unity /
UdonSharp.

## Immediate rules

- Match the conversational language to the user's language.
- Write comments and documentation in English unless there is a clear
  project-specific reason otherwise.
- If uncertainty, hidden risk, or missing context blocks a safe change,
  stop and ask a concise question before proceeding.

## IDD Workflow

This project uses Issue-Driven Development (IDD) with parallel AI
agents. Start with [docs/idd-workflow.md](../docs/idd-workflow.md) for the
cross-agent entry path and phase routing.

GitHub Copilot participates as the advisory PR reviewer
(`reviewPolicy: copilot-advisory`); this repository-wide guidance
applies during review. Copilot is excluded from the IDD execution
protocol files themselves
(`.github/instructions/idd-overview-core.instructions.md` sets
`excludeAgent: "code-review"`), which only an implementing agent needs.

Marker prefix: `dantalion-dotnet`. Merge policy: `fully_autonomous_merge`.
See [docs/idd-policy.md](../docs/idd-policy.md) for the full recorded
policy.
