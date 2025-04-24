My ASP.NET Core 8 Web API Project
Overview
This project is a Web API built using ASP.NET Core 8, following the principles of Clean Architecture. It provides a RESTful API for managing restaurant resources with features like CRUD operations, JWT authentication, Pagination, Sorting,  The project was developed as part of the "ASP.NET Core 8 Web API: Clean Architecture" 
Features

RESTful API: Implements GET, POST, PUT, and DELETE methods for restaurant and dish management.
Clean Architecture: Separates concerns into layers (Domain, Application, Infrastructure, and Presentation).
Authentication: Supports JWT-based authentication with role-based authorization.
Data Validation: Uses Data Annotations and DTOs for model validation.
Automapper: Maps between DTOs and entities for cleaner data transfer.
Pagination & Sorting: Supports paginated and sorted responses for restaurant and dish endpoints.

Error Handling: Implements exception filters and action filters for consistent API responses.

Project Structure

Domain: Contains entities and business logic.
Application: Includes DTOs, interfaces, and application logic.
Infrastructure: Handles data access and external services.
API: The presentation layer with controllers and API endpoints.

Technologies Used

ASP.NET Core 8
Entity Framework Core
JWT Authentication
Automapper
Swagger for API Documentation


API Documentation
The API is documented using Swagger, which provides a detailed overview of all available endpoints. You can access the Swagger UI 


API Endpoints

Dishes:

POST /api/restaurant/restaurant/dishes: Create a new dish.
GET /api/restaurant/restaurant/dishes: Get all dishes (supports Pagination and Sorting).
GET /api/restaurant/restaurant/dishes/{dishId}: Get a specific dish by ID.


Identity:

POST /api/Identity/register: Register a new user.
POST /api/Identity/login: Login and obtain a JWT token.
POST /api/Identity/refresh: Refresh the JWT token.
GET /api/Identity/confirmEmail: Confirm user email.
POST /api/Identity/resendConfirmationEmail: Resend confirmation email.
POST /api/Identity/forgetPassword: Request a password reset.
POST /api/Identity/resetPassword: Reset password.
GET /api/Identity/manage/info: Get user info.
PATCH /api/Identity/manage/info: Update user info.
POST /api/Identity/userRole: Assign a role to a user.
DELETE /api/Identity/userRole: Remove a role from a user.


Restaurant:

GET /api/restaurant: Get all restaurants (supports Pagination and Sorting).
POST /api/restaurant: Create a new restaurant.
GET /api/restaurant/{id}: Get a specific restaurant by ID.
PATCH /api/restaurant/{id}: Update a restaurant.



Using Pagination and Sorting

For endpoints like GET /api/restaurant and GET /api/restaurant/restaurant/dishes, you can use query parameters to control pagination and sorting:

pageNumber: The page number to retrieve (default: 1).
pageSize: Number of items per page (default: 10).
sortBy: The field to sort by (e.g., name).
sortDirection: The sort direction (asc or desc).

Example: GET /api/restaurant?pageNumber=2&pageSize=5&sortBy=name&sortDirection=asc


Authentication

Use the /api/Identity/login endpoint to obtain a JWT token.
Include the token in the Authorization header as Bearer <token> for protected endpoints.



