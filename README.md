TimeTracking API
Overview

TimeTracking API is a minimal ASP.NET Core Web API that allows employees to log their work hours and later retrieve or edit these entries. It is designed as a simple, clean backend solution demonstrating CRUD operations, validation, and database integration.

Features

Create time entries (POST /api/TimeEntries) with validation (hours per day ≤ 24)

Retrieve all time entries (GET /api/TimeEntries) with optional employee filter

Retrieve a single time entry by ID (GET /api/TimeEntries/{id})

Update an existing time entry (PUT /api/TimeEntries/{id})

Automatic SQLite database initialization

Swagger/OpenAPI documentation for easy testing

Technologies

ASP.NET Core 9 Web API

Dapper for lightweight data access

SQLite for simple database storage

FluentValidation for input validation

Dependency Injection (DI)

Swagger UI for API documentation
