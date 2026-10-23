# Employee Management API

An ASP.NET Core Web API built on .NET 8 for managing employee records and retrieving country, state, and city reference data. The application uses Entity Framework Core with SQL Server and separates API, data-access, model, and repository responsibilities.

## Features

- Retrieve the employee directory and an employee by employee code.
- Create, update, and delete employee records.
- Retrieve country, state, and city reference data.
- Handle employee profile-image operations through the file-helper component.
- Explore API endpoints through Swagger/OpenAPI in the Development environment.

## Technology stack

- **Backend:** ASP.NET Core Web API, .NET 8
- **Data access:** Entity Framework Core
- **Database:** Microsoft SQL Server
- **API documentation:** Swagger / OpenAPI
- **Architecture:** Controllers, models, data access, and repository layer

## Solution structure

~~~text
.
├── AngularApi.sln
├── AngularApi/
│   ├── Controllers/
│   ├── FileHelpers/
│   ├── Properties/
│   └── UIAPI.csproj
├── DAL/
│   ├── Entities/
│   └── AppDbContext.cs
├── Models/
└── Repository/
    ├── Implementation/
    ├── Interface/
    └── ConfigureService.cs
~~~

- **AngularApi** — HTTP endpoints, application startup, and file-helper implementation.
- **DAL** — Entity Framework Core context and database entities.
- **Models** — Models used by the API.
- **Repository** — Repository contracts, implementations, and dependency-registration logic.

## Prerequisites

- .NET 8 SDK
- SQL Server or SQL Server LocalDB
- A database whose schema matches the application's entities

## Getting started

### 1. Clone the repository

~~~powershell
git clone https://github.com/Shadabaj/EmployeeManagementApi.git
cd EmployeeManagementApi
~~~

### 2. Configure the database connection

The API reads its database connection from the .NET configuration key `ConnectionStrings:DbConnection`. For local development, you can provide the value as an environment variable instead of storing credentials in source control.

Example for PowerShell (replace the example server and database with your local values):

~~~powershell
$env:ConnectionStrings__DbConnection = "Server=localhost;Database=EmployeeManagement;Trusted_Connection=True;TrustServerCertificate=True"
~~~

Ensure the target database and required schema exist before starting the API. Never commit production credentials, access tokens, or private connection strings.

### 3. Restore and build

~~~powershell
dotnet restore .\AngularApi.sln
dotnet build .\AngularApi.sln --configuration Release
~~~

### 4. Run the API

~~~powershell
dotnet run --project .\AngularApi\UIAPI.csproj
~~~

When the application is running in the Development environment, open the Swagger UI at `/swagger` using the HTTPS or HTTP address shown in the console or launch profile.

## API overview

| Method | Route | Purpose |
| --- | --- | --- |
| GET | `/EmployeeDetails` | Return the employee directory |
| GET | `/Employee/{id}` | Retrieve an employee by employee code |
| POST | `/CreateEmployee` | Create an employee |
| PUT | `/EditEmployee` | Update an employee |
| DELETE | `/DeleteEmployee/{employeeCode}/{profileImage}` | Delete an employee and request profile-image cleanup |
| GET | `/GetCountry` | Return countries |
| GET | `/GetStates` | Return states |
| GET | `/GetCities` | Return cities |

See [docs/API.md](docs/API.md) for endpoint notes and response behavior.

## Development and production notes

- Swagger is enabled by the application in the Development environment.
- The current CORS policy allows any origin, method, and header. Restrict it to trusted client origins before deploying publicly.
- Review authentication, authorization, request validation, and error handling before using the API with real employee data.
- Review the profile-image deletion flow carefully; file paths should be resolved and validated on the server rather than trusted from arbitrary client input.
- A dedicated automated test project is not currently included in this repository. Add unit and integration tests as the API evolves.

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) before submitting changes.

## License

No license file is currently included. Add an explicit license before inviting others to reuse or redistribute the code.
