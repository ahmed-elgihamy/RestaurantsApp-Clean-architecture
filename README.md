My RestaurantsApp-Clean-architectur ASP.NET Core 8 Web API Project

Overview

This project is a Web API built using ASP.NET Core 8, following the principles of Clean Architecture. It provides a RESTful API for managing resources with features like CRUD operations, JWT authentication, and deployment to Azure. The project was developed as part of the "ASP.NET Core 8 Web API: Clean Architecture"



RESTful API: Implements GET, POST, PUT, and DELETE methods for resource management.



Clean Architecture: Separates concerns into layers (Domain, Application, Infrastructure, and Presentation).



Authentication: Supports JWT-based authentication with role-based authorization.



Data Validation: Uses Data Annotations and DTOs for model validation.



Automapper: Maps between DTOs and entities for cleaner data transfer.



Azure Deployment: Deployed to Azure App Service with continuous deployment via GitHub Actions.



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



Azure App Service



GitHub Actions for CI/CD
