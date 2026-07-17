
# Research Tracker

A full-stack research project management application built with React, ASP.NET Core, Entity Framework Core, SQL Server, and AWS.

The application allows users to create, view, edit, and delete research projects through a responsive React interface backed by a RESTful ASP.NET Core API.

## Technologies

### Frontend

- React
- JavaScript
- Vite
- HTML
- CSS

### Backend

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

### Cloud

- AWS Elastic Beanstalk
- Amazon RDS

## Features

- View all research projects
- Create new research projects
- Edit existing projects
- Delete projects with confirmation
- Track project title, researcher, status, description, and start date
- Search projects by title or researcher through the API
- Filter projects by status through the API
- Persist data using Entity Framework Core and SQL Server
- Health-check endpoint for deployment monitoring
- Backend deployed using AWS Elastic Beanstalk and Amazon RDS

<img width="744" height="242" alt="Application Environment" src="https://github.com/user-attachments/assets/7a0ad7d5-8c7e-48c3-a3fb-ec9910d974ec" />

## Project Structure

```text
ResearchTracker/
├── ResearchTrackerApi/       ASP.NET Core backend
├── ResearchTrackerClient/    React frontend
├── ResearchTracker.slnx
└── README.md
```

## Architecture

```text
React Client
    |
    | HTTP / JSON
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
```

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/researchprojects` | Retrieve all projects |
| GET | `/api/researchprojects/{id}` | Retrieve one project |
| GET | `/api/researchprojects/status/{status}` | Filter by status |
| GET | `/api/researchprojects/search?query=value` | Search projects |
| POST | `/api/researchprojects` | Create a project |
| PUT | `/api/researchprojects/{id}` | Update a project |
| DELETE | `/api/researchprojects/{id}` | Delete a project |
| GET | `/health` | Check API health |

<img width="929" height="408" alt="Command" src="https://github.com/user-attachments/assets/818cefc3-8315-43eb-b446-8a32d012e1a3" />

## Running Locally

### Prerequisites

- .NET 10 SDK
- Visual Studio 2026 with the ASP.NET and web development workload

### 1. Clone the repository

```powershell
git clone https://github.com/abbey-singh/ResearchTracker.git
cd ResearchTracker
```

### 2. Run the backend

Open a terminal in the repository root:

```powershell
cd ResearchTrackerApi
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

The terminal will display the API's local URL.

Swagger can usually be opened at:

```text
https://localhost:<port>/swagger
```

### 3. Run the frontend

Open a second terminal:

```powershell
cd ResearchTrackerClient
npm install
npm run dev
```

Open the local Vite URL shown in the terminal, usually:

```text
http://localhost:5173
```

Both the frontend and backend must be running for the application to work locally.

## Configuration

The React API base URL is configured in:

```text
ResearchTrackerClient/src/Services/researchProjectsApi.js
```

Update it to match the URL and port displayed when the ASP.NET Core API starts.

Database configuration is stored in the backend's application settings and can be overridden with environment variables.

Do not commit production connection strings, passwords, or other secrets.

   <img width="670" height="343" alt="Database" src="https://github.com/user-attachments/assets/192b15fa-8af4-4ad0-9e4f-00164c2afdf5" />
