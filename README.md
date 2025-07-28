A comprehensive, enterprise-grade Order Management System built with .NET 8, implementing modern architectural patterns including CQRS, MediatR, and Domain-Driven Design principles.
🚀 Features
Core Functionality

Customer Management: Create and manage customer profiles with order history
Product Catalog: Full product lifecycle management with inventory tracking
Order Processing: Complete order workflow with validation and status tracking
Invoice Generation: Automated invoice creation and management
Payment Integration: Support for multiple payment methods (Credit Card, PayPal, Bank Transfer)
Inventory Management: Real-time stock updates and availability checking

Business Logic

Tiered Discount System:

5% discount for orders over $100
10% discount for orders over $200


Order Validation: Stock availability and business rule validation
Email Notifications: Automated order confirmations and status updates
Audit Trail: Complete order history and status tracking

Technical Features

CQRS Pattern: Command Query Responsibility Segregation using MediatR
JWT Authentication: Secure token-based authentication
Role-Based Access Control (RBAC): Admin and Customer role management
RESTful API: Well-designed REST endpoints with OpenAPI documentation
Entity Framework Core: Code-first database approach with migrations
Swagger Integration: Interactive API documentation
Unit Testing: Comprehensive test coverage with xUnit
Logging: Structured logging with Serilog
Validation: FluentValidation for request validation

🏗️ Architecture
Design Patterns

CQRS (Command Query Responsibility Segregation): Separates read and write operations
Mediator Pattern: Decouples request/response handling using MediatR
Repository Pattern: Data access abstraction layer
Unit of Work: Transaction management and data consistency
Domain-Driven Design: Rich domain models with business logic encapsulation

Project Structure
OrderManagementSystem/
├── src/
│   ├── OrderManagementSystem.API/          # Web API Layer
│   ├── OrderManagementSystem.Application/   # Application Layer (CQRS)
│   ├── OrderManagementSystem.Domain/        # Domain Layer
│   ├── OrderManagementSystem.Infrastructure/ # Infrastructure Layer
│   └── OrderManagementSystem.Queries/        # Queries Layer
|_
🛠️ Technology Stack
Backend

.NET 9: Latest LTS version of .NET
ASP.NET Core: Web API framework
Entity Framework Core: ORM for data access
MediatR: Mediator pattern implementation
FluentValidation: Request validation
Microsoft Identity: Authentication and authorization
JWT Bearer: Token-based authentication
Serilog: Structured logging
BCrypt.NET: Password hashing

Database
SQLite:

Documentation

Swagger/OpenAPI: API documentation
Postman Collection: API testing collection

🚦 Getting Started
Prerequisites

.NET 9 SDK
SQLite 
Visual Studio 2022 or VS Code
Git

Installation

Clone the repository
bashgit clone https://github.com/mohammad-elhaw/order-management-system.git
cd order-management-system

Restore dependencies
bashdotnet restore


Run database migrations
bashdotnet ef database update --project src/OrderManagementSystem.Infrastructure

Run the application
bashdotnet run --project src/OrderManagementSystem.API

Access the application

API: https://localhost:7070
Swagger UI: https://localhost:7070/swagger

API Documentation

Authentication Endpoints
POST /api/auth/register     # Register new user
POST /api/auth/login        # User login
POST /api/auth/refresh      # Refresh token

Customer Endpoints
POST   /api/customers                    # Create customer
GET    /api/customers/{id}               # Get customer
GET    /api/customers/{id}/orders        # Get customer orders
PUT    /api/customers/{id}               # Update customer
DELETE /api/customers/{id}               # Delete customer

Product Endpoints
GET    /api/products                     # Get all products
GET    /api/products/{id}                # Get product
POST   /api/products                     # Create product (Admin)
PUT    /api/products/{id}                # Update product (Admin)
DELETE /api/products/{id}                # Delete product (Admin)

Order Endpoints
POST   /api/orders                       # Create order
GET    /api/orders/{id}                  # Get order
GET    /api/orders                       # Get all orders (Admin)
PUT    /api/orders/{id}/status           # Update order status (Admin)
DELETE /api/orders/{id}                  # Cancel order

Invoice Endpoints
GET    /api/invoices/{id}                # Get invoice (Admin)
GET    /api/invoices                     # Get all invoices (Admin)
GET    /api/orders/{id}/invoice          # Get order invoice
