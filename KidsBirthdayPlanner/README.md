# KidsBirthdayPlanner

KidsBirthdayPlanner is an ASP.NET Core MVC web application for organizing children's birthday parties.  
The platform allows users to browse party offers, make reservations, leave reviews, and explore different birthday themes, cakes, balloons, and locations.

The project was developed as part of the **ASP.NET Advanced Course @ SoftUni** and demonstrates advanced ASP.NET Core development practices, layered architecture, security, testing, and deployment readiness.

---

## Features

- User registration and login
- Role-based authentication and authorization
- Admin area for management
- Create, edit, delete birthday parties
- Search birthday parties by theme or location
- Pagination for easier browsing
- Reservation system
- Review system
- Custom error pages (404 / 500)
- Responsive modern UI design
- Database seeding with sample data
- Unit tested business logic

---

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Razor Views
- Bootstrap
- HTML / CSS / JavaScript
- xUnit
- EF Core InMemory Database

---

## Architecture and Layers

The project follows a **Layered (N-Tier) Architecture** for better maintainability and separation of concerns.

### Data Layer
Contains:

- Entity models
- Application DbContext
- Entity Framework Core configuration
- Database migrations
- Seed data

### Service Layer
Contains the business logic of the application.

Examples:

- Birthday party management
- Search and filtering
- Pagination logic
- CRUD operations
- Data mapping to ViewModels

### Web Layer (MVC)
Contains:

- Controllers
- Razor Views
- ViewModels
- Areas
- User interface logic

This architecture improves readability, scalability, and testability.

---

## Entity Models

The project includes multiple entities such as:

- BirthdayParty
- Theme
- Cake
- Balloon
- Reservation
- Review

---

## Roles

### Administrator

Administrators can:

- Create birthday parties
- Edit birthday parties
- Delete birthday parties
- Access Admin Area
- Manage platform content

### User

Registered users can:

- Browse birthday parties
- Search parties
- View details
- Make reservations
- Leave reviews

---

## Security Features

The application includes multiple security protections:

- ASP.NET Identity authentication system
- Role-based authorization
- Anti-forgery token validation in POST requests
- Client-side validation
- Server-side validation
- Razor automatic HTML encoding
- Restricted admin functionality
- Protection against common vulnerabilities such as CSRF and invalid form submission

---

## Validation

The project uses validation through:

- Data Annotations
- Required fields
- Range validation
- String length restrictions
- ModelState validation
- Client-side validation scripts

---

## Search and Pagination

Users can easily browse the platform using:

- Search by theme
- Search by location
- Pagination for better navigation through large result sets

---

## Error Handling

Custom pages are implemented for:

- 404 Not Found
- 500 Internal Server Error

The application also prevents crashes through proper validation and defensive checks.

---

## Seeding

The database is seeded with initial sample data including:

- Themes
- Cakes
- Balloons
- Roles
- Administrator account
- Sample birthday parties

---

## Unit Testing

The project includes unit tests focused on the Service Layer business logic.

### Tools Used

- xUnit
- EF Core InMemory Database

### Tested Functionality

- Retrieving all parties
- Search by theme
- Search by location
- Pagination logic
- Get by Id
- Create party
- Edit party
- Delete party

The tests validate important business rules and application behavior.

---

## How to Run Locally

1. Open the project in **Visual Studio 2022**
2. Configure your SQL Server connection string in:

```json
appsettings.json