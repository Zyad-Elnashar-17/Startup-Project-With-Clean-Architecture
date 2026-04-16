# Technical Project Implementation Report: Clean Architecture with .NET 8

## 🚀 1. Project Overview & Framework Selection
We initiated the project using **.NET 8**. This version was strategically chosen to ensure built-in support for **Swagger (OpenAPI)**, which is no longer the default in .NET 10. By starting with .NET 8, we optimized our development time and ensured immediate access to the API testing interface.

---

## 🏗️ 2. Solution Structure & Dependencies
The solution follows the **Clean Architecture** principles, divided into four main layers to ensure **"Separation of Concerns"**.

### Layer Responsibilities & Dependencies:

| Layer | Responsibility | Dependencies |
| :--- | :--- | :--- |
| **Domain** | Entities, Enums, and Core Interfaces. | **None** (Core Layer). |
| **Application** | Business Logic, CQRS, MediatR Handlers, and DTOs. | **Domain** |
| **Infrastructure** | EF Core DbContext, Migrations, and Repository Implementations. | **Application** |
| **API (Presentation)** | Controllers, Middleware, and Dependency Injection. | **Infrastructure** |

---

## 🛠️ 3. Core Architectural Patterns

### A. Repository Pattern & Data Access
To keep the code maintainable, we avoided calling AppDbContext directly from the logic layer. Instead:**. 
* **Abstraction:** We defined an Interface (`IUserRepository`) in the **Domain** layer.
* **Implementation:** The actual logic to communicate with SQL Server via EF Core was implemented in the **Infrastructure** layer.
* **Benefit:** This prevents the `AppDbContext` from leaking into our business logic.

### B. CQRS with MediatR
We implemented **CQRS (Command Query Responsibility Segregation)** to separate read and write operations:
* **Queries:** For retrieving data (e.g., `GetAllUserQuery`).
* **Commands:** For data modification (e.g., `CreateUserCommand`).
* **MediatR:** Used as a "Mediator" to decouple the Controllers from the Handlers.

### C. Validation via Pipeline Behaviors
We integrated **FluentValidation** to ensure data integrity. 
* **Importance:** It prevents corrupted data from reaching the database and centralizes validation logic.
* **Implementation:** Instead of manual checks in every method, we used **MediatR Pipeline Behaviors** to validate requests automatically before they reach the Handlers.

---

## 🧪 4. Implementation & Testing Flow
We followed a systematic approach to build and test each feature from end-to-end:

1.  **Domain:** Defined the `User` entity and the `IUserRepository` contract.
2.  **Infrastructure:** Set up `AppDbContext`, generated **Migrations**, and completed the Repository implementation.
3.  **Application:** Developed the **Query/Command** records and their corresponding **Handlers**.
4.  **API:** Developed the `UsersController` and registered all dependencies in `Program.cs` using **Dependency Injection (DI)**.

### ✅ Final Test Results:
* **GET /api/Users:** Successfully retrieved the user list from the database.
* **POST /api/Users:** Successfully validated, created, and persisted new user records.

---

## 📌 5. Conclusion
The project is now built on a solid foundation that is:
* **Scalable:** Easy to add new entities and features.
* **Testable:** Logic is separated from infrastructure, making Unit Testing possible.
* **Professional:** Adheres to industry-standard design patterns.
