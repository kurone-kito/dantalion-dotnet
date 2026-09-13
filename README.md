# dantalion-dotnet
🦁 CLI app and NuGet library that calculates the personality from the birthday.

## Development

This repository uses [Issue-Driven Development (IDD)](docs/idd-workflow.md)
with parallel AI agents; see [docs/idd-policy.md](docs/idd-policy.md) for
the recorded policy.

### IDD labels

| Label | Purpose | Config field |
| --- | --- | --- |
| `roadmap` | Identifies a roadmap issue that coordinates child work. | `labels.roadmapLabelName` |
| `status:blocked-by-human` | Escape hatch for issues blocked on a person, credential, asset, or outside system. | `labels.blockedByHumanLabelName` |
| `status:needs-decision` | Escape hatch for issues blocked on a product, policy, or design decision. | `labels.needsDecisionLabelName` |
| `idd:ready` | Maintainer approval signal for the IDD issue-author approval gate. | `approvalSignals.readyLabelName` |
| `status:authoring` | Hold label the issue-authoring skill applies while drafting an issue. | `issueAuthoring.authoringLabelName` |

### Claude Code

`.claude/settings.json` records a curated permission baseline for Claude
Code sessions (see `docs/permissions.md#claude-code-permission-baseline`),
and `.claude/skills/issue-authoring/` provides the issue-authoring skill
used to decompose larger requests into IDD-ready issues.
