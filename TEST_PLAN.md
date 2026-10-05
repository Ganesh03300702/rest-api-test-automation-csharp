# API Test Plan

## Objective
Validate core REST API behavior through automated tests.

## Scenarios
| ID | Scenario | Expected |
|---|---|---|
| API-001 | GET /todos/1 | 200 + valid JSON |
| API-002 | GET unknown todo | 404 |
| API-003 | POST /todos | 201 + returned payload |

## Test approach
Use reusable HTTP client helpers and NUnit assertions. Keep tests independent and suitable for regression execution.
