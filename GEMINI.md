# Guidelines for AI Agents

This file is for Antigravity CLI (formerly Gemini CLI). See
`CLAUDE.md` for Claude Code and `AGENTS.md` for Codex CLI, OpenCode,
and Grok Build.

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
agents. Start with [docs/idd-workflow.md](docs/idd-workflow.md) for the
cross-agent entry path and phase routing.

Before starting IDD work, open
`.github/instructions/idd-overview-core.instructions.md`. Open the
routed phase file manually when the current step changes.

Marker prefix: `dantalion-dotnet`. Merge policy: `fully_autonomous_merge`.
See [docs/idd-policy.md](docs/idd-policy.md) for the full recorded
policy.
