# Task Management App Wiki

## 1. Project Overview
### Task Management App
This application is a **Task Management System** that allows users to create, update, and retrieve tasks. It provides a RESTful API using **ASP.NET Core Web API** on the backend and a **React** frontend for the user interface.

## 2. Technologies Used
### Backend: ASP.NET Core Web API
- **Repository Design Pattern**: Used to structure data access code and provide separation of concerns between business logic and data access logic.
- **ADO.NET**: Used for database interaction.
- **Swagger**: Used for API documentation and easy testing of API endpoints.

### Frontend: React.js
## 3. Project Structure
### Backend (ASP.NET Core Web API)

## 4. Features
- **Create Task**: Users can create new tasks by providing a task name, description, and deadline.
- **Update Task**: Users can update existing tasks.
- **Get Task**: Users can view the details of a task by ID or view a list of tasks.
- **Delete Task**: Users can delete a task (if implemented).

## 5. API Endpoints
The API exposes the following endpoints to manage tasks. You can explore these endpoints in **Swagger**.

### GET /api/TaskManagement/GetAllTasks
- **Description**: Retrieves all tasks.
- **Response**: A list of tasks.

### GET /api/TaskManagement/GetTaskDetails/{taskItemId}
- **Description**: Retrieves a task by its ID.
- **Response**: Task details for the given ID.

### POST /api/TaskManagement/CreateNewTaskItem
- **Description**: Creates a new task.
- **Request Body**: JSON object containing task name, description, and deadline.
- **Response**: Created task details.

### PUT /api/TaskManagement/UpdateTaskDetails/{id}
- **Description**: Updates an existing task by ID.
- **Request Body**: JSON object with updated task information.
- **Response**: Updated task details.

### DELETE /api/TaskManagement/TaskManagement{id}
- **Description**: Deletes a task by ID.
- **Response**: Success message or error message.

You can access and test these endpoints using **Swagger UI**, which is available when the backend API is running.

## 6. Database and ADO.NET
- **Database**: The application uses **ADO.NET** for database access. 
- **SQL Server**:
- **Repository Design Pattern**: Used to abstract the data access layer. This provides a cleaner architecture and better separation of concerns between business logic and data storage logic.

### Example ADO.NET Usage:
- **Database Connection**: Connection strings are stored in `appsettings.json`.
- **Database Operations**: Methods for querying the database (SELECT), inserting (INSERT), updating (UPDATE), and deleting (DELETE) tasks are implemented within repository classes.

## 7. Setting Up the Project
### Backend (ASP.NET Core Web API)
1. Clone or download the repository for the backend.
2. Open the solution in **Visual Studio** or **Visual Studio Code**.
3. Install necessary NuGet packages:
   - `Microsoft.Data.SqlClient`
   - `Microsoft.AspNetCore.Swagger`
4. Sql Scripts to execure:(Note All the Scripts are in DB Executor Folder in TaskManagement.Api project)
    - `Create Data Base named `**TaskManagementDb**
    - `Run Create Table Scripts`
    - `Run Insert Scripts`
    - `Run Stored Procedures`

5. Run the application locally:
   - The backend API will be hosted on a local server (e.g., `http://localhost:5000`).

6. **Swagger UI** will be available to interact with API endpoints (e.g., `http://localhost:5000/swagger`).

### Frontend (React)
1. Clone or download the repository for the React application.
2. Navigate to the project directory and install dependencies:
   
 - `npm install`
 - `npm run build`
 - `npm run dev`



   

