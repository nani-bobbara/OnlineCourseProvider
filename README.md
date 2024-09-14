# Online Course Provider - Backend Service 
  
This project provides the backend implementation for an online course provider, using C#.NET Core, Entity Framework, and SQL Server. This project involves setting up a course catalog, maintaining a list of users, and tracking the video lessons users have watched.

## Table of Contents
- Prerequisites
- Project Setup
- Running the Project
- API Endpoints
- Testing the Application
- Verifying Submission
- Coding Standards, Desing Pattrens & Best practices

---

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/) for API testing (optional)

## Project Setup

1. **Clone the repository:**
    ```bash
    git clone https://github.com/nani-bobbara/OnlineCourseProvider.git
    ```
    
 2. **Navigate to the project directory using the cd command:**
    ```bash
    cd OnlineCourseProvider
    ```

3. **Configure the database connection string:**
   - Update the `appsettings.json` file with your SQL Server connection string:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=OnlineCourseDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
     }
     ```

3. **Install dependencies:**
    ```bash
    dotnet restore
    ```

4. **Apply migrations to create the database:** [optional , it generates random data in Course(100),section(500),lesson(2000) and user(100) tables)
   
      For testing purpose I created "FakeDataService" using Bogus library. It automatically generates fake data with given number of records, feel free to change the records count
      ```bash
         public static void SeedData(ModelBuilder modelBuilder)
         {
             // Seed initial data
             var courses = GenerateCourses(100);
             modelBuilder.Entity<Course>().HasData(courses);
         
             var sections = GenerateSections(courses,500);
             modelBuilder.Entity<Section>().HasData(sections);
         
             var lessons = GenerateLessons(sections,2000);
             modelBuilder.Entity<Lesson>().HasData(lessons);
         
             var users = GenerateUsers(100);
             modelBuilder.Entity<User>().HasData(users);
         }
      ```
4. **Apply migrations to create the database:**

   ```bash
    dotnet ef migrations add InitialSetup
    ```

    ```bash
    dotnet ef database update
    ```

## Running the Project

   1.**Build the Project:**     
       
       ```bash
       dotnet Build
       dotnet run
      ```
   2.**The API will be available at** https://localhost:5001  **with swagger interface** 


## Coding Standards, Desing Pattrens & Best practices

This project adheres to industry-standard best practices, ensuring maintainability, scalability, and performance:

- Repository Pattern: Separation of data access logic, promoting maintainability and testability.
- Dependency Injection: Loose coupling of components for flexibility and easier unit testing.
- Middleware Error Handling: Centralized error handling for consistent API responses.
- Logging: Implemented using ILoggerManager for structured and centralized logging.
- SOLID Principles: Ensuring high cohesion and low coupling throughout the architecture.
- Clean Architecture: Well-organized, modular code with clear separation of concerns.
   
