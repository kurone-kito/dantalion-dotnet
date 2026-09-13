## IDD Policy Configuration

This repository uses the following IDD policies:

### Development Branch

**Branch**: `main`

### Merge Policy

**Policy**: `fully_autonomous_merge`

### PR Review Policy

**Profile**: `copilot-advisory`

### Review-Thread Resolution Policy

**Policy**: `fast-agent-resolve`

### Critique-Loop Profile

**Profile**: `distributed-defaults`

### Credential Scope

**Scope**: `Worker agent for normal phases; merge-capable agent for the same trusted session under fully_autonomous_merge`

### Claim Timing

- **claim-stale-age**: 24 h (distributed default)
- **claim-heartbeat-interval**: 12 h (distributed default)

### CI Wait Policy

- **running timeout**: `PT30M` / 30 min (distributed default, not confirmed by this hearing item)
- **generation timeout**: `PT10M` / 10 min (distributed default, not confirmed by this hearing item)
- **rerun policy**: `rerun-once`

### Issue-Author Approval Gate

**Selection**: `enabled-by-default`

### Maintainer Approval Actor Policy

**Policy**: `owners-and-maintainers-only`

### Issue-Authoring Companion

**Status**: `not installed` (core-bootstrap temporary state)

The confirmed hearing's real answer is `installed`, with native
destination `.claude/skills/issue-authoring/`. Per
`docs/onboarding/issue-mediated-bootstrap.md`, the core-bootstrap PR
(#4) always records the temporary `not installed` state here and
leaves the companion files out of this PR; #7 installs the companion
and flips this status to `installed`.

### Helper Runtime Profile

**Profile**: `ephemeral-npx`

### IDD Label Names

**Selection**: `distributed-defaults`

### Up-to-Date-Head Ruleset

**Policy**: `disabled`

### Bootstrap Execution Mode

**Mode**: `issue-mediated`
