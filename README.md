# Basic use of Strongly Typed query objects

Features:

- Basic net6.0 API
- Optional query parameter provided to GET method on /CountryCode via query object (CountryCodeQuery)
- Validation provided via FluentValidation and plugged in to ModelState
- Returns a ProblemDetails object to the client when validation fails
- Separate testing project with testing for validators shown
- FluentAssertions used in tests to help readablity

Benefits:

- Very thin controller with all validation logic automatically kicking in on use of object
- Validation re-used where ever query object is re-used
- Validations independently testable
