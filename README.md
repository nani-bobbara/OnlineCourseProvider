# OnlineCourseProvider
Online Course Provider  


`This project is a backend structure for an online course provider similar to Coursera or Udemy. It includes endpoints to retrieve detailed information about courses, sections, and lessons, and to log the percentage of each video lesson a user has watched.

**## Technology Stack**- C#.NET Core
- Entity Framework
- SQL Server

**## Setup**1. Clone the repository
2. Configure the database connection string in `appsettings.json`
3. Run the following commands to apply migrations and start the application:
   ```bash
   dotnet ef database update
   dotnet run`

## Endpoints

- **`GET /api/course`**: Retrieve all courses
- **`GET /api/course/{id}`**: Retrieve a course by ID
- **`POST /api/progress`**: Log lesson progress