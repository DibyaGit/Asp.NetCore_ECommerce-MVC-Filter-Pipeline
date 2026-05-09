# ASP.NET Core MVC: Advanced Filters Implementation

An enterprise-style ASP.NET Core MVC application demonstrating advanced custom filter implementations for handling cross-cutting concerns such as logging, authentication, and global exception handling. This project showcases clean architecture principles, Dependency Injection (DI), and automated unit testing using xUnit and Moq.

---

## 📖 Project Overview

In modern web applications, concerns like logging, authorization, and error handling are often repeated throughout controllers and services, making the codebase difficult to maintain.

This project demonstrates how to extract those responsibilities into reusable **ASP.NET Core MVC Filters**, resulting in cleaner, more maintainable, and scalable application architecture.

The application simulates an **E-Commerce platform** where incoming requests are intercepted, validated, logged, and protected through a custom filter pipeline.

---

# ✨ Features

## 🔹 Custom Request & Response Logging (`IActionFilter`)

A custom logging filter intercepts every HTTP request and response.

### Responsibilities:

* Logs requested URLs
* Captures HTTP methods (`GET`, `POST`, etc.)
* Records response status codes
* Helps monitor request lifecycle execution

### Benefits:

* Cleaner controllers
* Centralized request monitoring
* Easier debugging and diagnostics

---

## 🔹 Authorization Security Layer (`IAuthorizationFilter`)

A custom authorization filter protects secured endpoints such as a VIP Privacy page.

### Responsibilities:

* Validates users before controller execution
* Uses Dependency Injection to access authentication services
* Returns `401 Unauthorized` for invalid users

### Benefits:

* Centralized security logic
* Reusable authorization mechanism
* Better separation of concerns

---

## 🔹 Global Exception Handling (`IExceptionFilter`)

A globally registered exception filter acts as a centralized safety net for unhandled application errors.

### Responsibilities:

* Catches unhandled exceptions application-wide
* Logs detailed internal error information
* Returns clean and safe `500 Internal Server Error` responses

### Benefits:

* Prevents sensitive stack trace exposure
* Improves application stability
* Provides production-ready error handling

---

## 🔹 Automated Unit Testing

The solution includes a dedicated testing project using **xUnit** and **Moq**.

### Test Coverage:

* Exception filter behavior
* Mocked `HttpContext`
* Mocked loggers and dependencies
* Validation of filter responses under failure scenarios

### Benefits:

* Reliable filter behavior
* Safer refactoring
* Improved code quality

---

# 🛠️ Technologies Used

| Technology                 | Purpose               |
| -------------------------- | --------------------- |
| .NET 8.0                   | Application Framework |
| ASP.NET Core MVC           | Web Architecture      |
| C#                         | Programming Language  |
| Dependency Injection (DI)  | Service Management    |
| Inversion of Control (IoC) | Architectural Pattern |
| xUnit                      | Unit Testing          |
| Moq                        | Mocking Framework     |

---

# 📂 Project Structure

```text
ECommerceApp/
├── Controllers/
│   └── HomeController.cs
│       # Uses [TypeFilter] to apply custom filters
│
├── Filters/
│   ├── AuthFilter.cs
│   │   # Implements IAuthorizationFilter
│   │
│   ├── GlobalExceptionFilter.cs
│   │   # Implements IExceptionFilter
│   │
│   └── LoggingFilter.cs
│       # Implements IActionFilter
│
├── Services/
│   ├── IAuthService.cs
│   │   # Authentication contract
│   │
│   └── AuthService.cs
│       # Simulated authentication service
│
└── Program.cs
    # Registers services and global filters


ECommerceApp.Tests/
└── UnitTest1.cs
    # xUnit + Moq tests for custom filters
```

---

# ⚙️ Getting Started

## 1️⃣ Clone the Repository

```bash
git clone https://github.com/yourusername/your-repository-name.git
```

---

## 2️⃣ Navigate to the Project Directory

```bash
cd ECommerceApp
```

---

## 3️⃣ Build the Application

```bash
dotnet build
```

---

## 4️⃣ Run the Application

```bash
dotnet run
```

---

## 5️⃣ Open in Browser

Navigate to:

```text
https://localhost:xxxx
```

Check the console output for the exact running port.

---

# 🧪 Running Unit Tests

Execute the following command to run all tests:

```bash
dotnet test
```

---

# 🏗️ Architectural Highlights

This project demonstrates several important software engineering principles:

* ✅ Separation of Concerns
* ✅ Clean Controller Design
* ✅ Reusable Middleware-like Filters
* ✅ Dependency Injection Best Practices
* ✅ Centralized Error Management
* ✅ Testable Architecture

---

# 📸 Example Use Cases

| Scenario                    | Filter Used             |
| --------------------------- | ----------------------- |
| Logging incoming requests   | `LoggingFilter`         |
| Securing VIP pages          | `AuthFilter`            |
| Handling unexpected crashes | `GlobalExceptionFilter` |

---

# 🚀 Future Improvements

Possible enhancements for future development:

* JWT Authentication Integration
* Database-backed User Authentication
* Structured Logging with Serilog
* Role-Based Authorization
* API Versioning
* Swagger/OpenAPI Integration
* Docker Support
* CI/CD Pipeline Setup

---




