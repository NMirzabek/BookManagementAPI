# BookManagementAPI

## Overview

BookManagementAPI is an ASP.NET Core Web API project designed for managing a collection of books. It demonstrates basic
CRUD operations including soft deletion and bulk inserts. This project is built using several modern components to
streamline development and deployment.

## Installed Components

- **.NET SDK 8**  
  The project targets ASP.NET Core and is built using the latest LTS version of .NET.

- **ASP.NET Core Web API**  
  Provides the framework for building RESTful APIs.

- **Entity Framework Core**  
  Used for data access and ORM (Object Relational Mapping).
    - **Microsoft.EntityFrameworkCore**: The core package for EF Core.
    - **Microsoft.EntityFrameworkCore.SqlServer**: EF Core provider for SQL Server.
    - **Microsoft.EntityFrameworkCore.Tools**: Enables EF Core migrations and other tooling.

- **SQL Server**  
  The application uses SQL Server as its database. You can connect to LocalDB, SQL Server Express, or a full SQL Server
  instance.

- **Swagger**  
  Integrated for API documentation and testing directly through the browser.

- **JetBrains Rider**  
  The project is set up with Rider in mind, though it’s fully compatible with other IDEs like Visual Studio.

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository_url>
   cd BookManagementAPI
