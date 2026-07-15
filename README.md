
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

<img width="744" height="242" alt="Application Environment" src="https://github.com/user-attachments/assets/7a0ad7d5-8c7e-48c3-a3fb-ec9910d974ec" />

## Architecture

Client / Swagger
       |
       v
ASP.NET Core REST API
       |
       v
Service Layer
       |
       v
Entity Framework Core
       |
       v
SQL Server / Amazon RDS

## API Endpoints

- `GET /api/researchprojects`
- `GET /api/researchprojects/{id}`
- `GET /api/researchprojects/status/{status}`
- `GET /api/researchprojects/search?query=value`
- `POST /api/researchprojects`
- `PUT /api/researchprojects/{id}`
- `DELETE /api/researchprojects/{id}`
- `GET /health`

<img width="929" height="408" alt="Command" src="https://github.com/user-attachments/assets/818cefc3-8315-43eb-b446-8a32d012e1a3" />

## Running Locally

### Prerequisites

- .NET 10 SDK
- Visual Studio 2026 with the ASP.NET and web development workload

### Setup

1. Clone the repository
2. Open a PowerShell terminal in the project directory.
3. Run the following commands:

   ```bash
   dotnet restore
   dotnet tool install --global dotnet-ef
   dotnet ef database update
   dotnet run
   ```
   
4. Open Swagger using the local URL and port displayed in the terminal, for example:

```text
https://localhost:5274/swagger
```

   <img width="670" height="343" alt="Database" src="https://github.com/user-attachments/assets/192b15fa-8af4-4ad0-9e4f-00164c2afdf5" />
