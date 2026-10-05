# REST API Test Automation Framework

A C# + NUnit API testing project demonstrating REST API automation, positive/negative testing, response validation, and regression-ready test organization.

## Requirements
- .NET 8 SDK
- Internet access for the public demo API

## Run
```bash
cd ApiTestFramework
dotnet restore
dotnet test
```

## Coverage
- GET success validation
- GET negative/not-found validation
- POST success validation
- HTTP status assertions
- JSON response validation
- Test setup/teardown
- Reusable API client abstraction

## Notes
The project uses JSONPlaceholder as a public demo API. Its behavior is designed for testing examples and should not be treated as a production service.

## Interview topics
Be prepared to explain REST, HTTP methods, status codes, assertions, positive vs negative testing, test isolation, API client abstraction, regression testing, and test reporting.
