# Research Tracker API

A RESTful ASP.NET Core Web API for managing research projects.

## Technologies

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- AWS Elastic Beanstalk
- Amazon RDS
- Swagger/OpenAPI

## Features

- Create, retrieve, update, and delete research projects
- Search projects by title or researcher
- Filter projects by status
- DTO-based request models
- Service-layer architecture
- Entity Framework Core migrations
- Health-check endpoint
- AWS cloud deployment

## API Endpoints

- `GET /api/researchprojects`
- `GET /api/researchprojects/{id}`
- `GET /api/researchprojects/status/{status}`
- `GET /api/researchprojects/search?query=value`
- `POST /api/researchprojects`
- `PUT /api/researchprojects/{id}`
- `DELETE /api/researchprojects/{id}`
- `GET /health`

## Running Locally

1. Install the .NET SDK and SQL Server LocalDB.
2. Update the database:

   ```bash
   dotnet ef database update