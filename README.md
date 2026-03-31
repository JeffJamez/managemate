# ManageMate - Enterprise Employee Management System

> A full-featured employee management platform built with **.NET 9.0** and **Blazor Server**, demonstrating enterprise-grade architecture and modern .NET ecosystem mastery.

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-blue)](https://dotnet.microsoft.com/)
[![Blazor Server](https://img.shields.io/badge/Blazor-Server-purple)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Entity Framework Core](https://img.shields.io/badge/EFCore-9.0-green)](https://learn.microsoft.com/ef/core/)

---

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                        ManageMate                               │
├─────────────────────────────────────────────────────────────────┤
│  Presentation Layer    │  Blazor Server (InteractiveServer)     │
│  ├─ Admin Dashboard    │  ├─ Role-based Layouts                 │
│  ├─ Manager Dashboard  │  ├─ Component-based UI                 │
│  └─ Employee Portal    │  └─ State Management                   │
├────────────────────────┼────────────────────────────────────────┤
│  Business Logic        │  Services + Authorization              │
│  ├─ Auth Service       │  ├─ Cookie Authentication              │
│  ├─ Task Management    │  ├─ OTP Email Verification             │
│  └─ Analytics          │  └─ Role-Based Access Control          │
├────────────────────────┼────────────────────────────────────────┤
│  Data Access Layer     │  Entity Framework Core 9.0             │
│  ├─ Code-First Migrations                                       │
│  ├─ Pomelo MySQL Provider                                       │
│  └─ Fluent API Configurations                                   │
└─────────────────────────────────────────────────────────────────┘
```

---

## Technology Stack

| Category | Technology | Purpose |
|----------|------------|---------|
| **Runtime** | .NET 9.0 | Modern .NET platform |
| **UI Framework** | Blazor Server | Interactive WebUI |
| **ORM** | EF Core 9.0 | Database abstraction |
| **Database** | MySQL (via Pomelo) | Relational data |
| **Authentication** | Cookie + OTP | Secure access control |
| **Password Hashing** | BCrypt.Net | Secure credential storage |
| **Email Service** | Postmark | Transactional emails |

---

## Domain Model Design

The application implements a sophisticated relational data model with **complex entity relationships**:

### Entity Relationship Diagram

```
┌──────────────┐       ┌──────────────┐       ┌──────────────┐
│    User      │       │  TaskToDo    │       │  UserTask    │
├──────────────┤       ├──────────────┤       ├──────────────┤
│ UserId (PK)  │◄──────│ CreatedById  │       │ Id (PK)      │
│ Email (UK)   │       │ TaskId (PK)  │◄──────│ TaskId (FK)  │
│ UserType     │       │ Name         │       │ EmployeeId   │
│ Password     │       │ Deadline     │       └──────────────┘
│ Skills       │       │ Status       │
│ MinWorkHours │       │ Rating       │
└──────┬───────┘       └──────────────┘
       │
       │ 1:N
       ▼
┌──────────────┐       ┌──────────────┐
│   Meeting    │       │   WorkLog    │
├──────────────┤       ├──────────────┤
│ Id (PK)      │       │ Id (PK)      │
│ OwnerId (FK) │       │ EmployeeId   │
│ Agenda       │       │ LogDate      │
│ Date         │       │ TotalMinutes │
└──────┬───────┘       └──────┬───────┘
       │                      │
       │ 1:N                  │ 1:N
       ▼                      ▼
┌──────────────┐       ┌──────────────┐
│MeetingPartic │       │WorkSession   │
├──────────────┤       ├──────────────┤
│ Id (PK)      │       │ Id (PK)      │
│ MeetingId(FK)│       │ WorkLogId(FK)│
│ ParticipantId│       │ CheckInTime  │
│ Notified     │       │ CheckoutTime │
└──────────────┘       └──────────────┘
```

### Key Relationships Implemented

- **One-to-Many**: User → Tasks, User → WorkLogs, Department → Members
- **Many-to-Many**: TaskToDo ↔ User (via UserTask junction table)
- **Self-Referential**: User → User (manager-employee hierarchy)
- **Composite Keys**: Proper FK constraints with cascade deletes

---

## Features

### Authentication & Authorization
- Cookie-based authentication with claim-based identity
- OTP email verification using Postmark API
- BCrypt password hashing for secure credential storage
- Role-based access control (Admin, TaskManager, Employee)

### Task Management
- Kanban-style workflow: `UnAssigned → InProgress → Complete → Reviewed`
- Skill-based task assignment
- Deadline tracking with notifications
- Rating and review system for completed tasks

### Organization Management
- Department creation and management
- Member assignment to departments
- Organizational hierarchy visualization

### Meeting Scheduling
- Meeting creation with agenda
- Participant management
- Notification tracking

### Time Tracking
- Daily work log with multiple sessions
- Check-in/Check-out time recording
- Automatic total hours calculation

### Analytics Dashboards
- Role-specific dashboards
- Performance metrics and reporting
- Working hours compliance tracking

---

## Project Structure

```
Managemate/
├── Components/
│   ├── Layout/
│   │   ├── AdminDashboardLayout.razor
│   │   ├── UserDashboardLayout.razor
│   │   └── AuthLayout.razor
│   └── Pages/
│       ├── Admin/         # Admin-only pages
│       ├── Manager/       # TaskManager pages
│       ├── Employee/      # Employee portal
│       └── auth/          # Login/Signup/Verify
├── Controllers/
│   └── AuthService.cs
├── Helpers/
│   ├── PasswordHasher.cs
│   └── Skills.cs
├── Migrations/
│   └── 20250310140044_remodelled.cs
├── Models/
│   ├── User.cs
│   ├── TaskToDo.cs
│   ├── Department.cs
│   ├── Meeting.cs
│   ├── WorkLog.cs
│   └── DbContext.cs
├── Program.cs
└── Managemate.csproj
```

---

## Code Highlights

### Entity Framework Core Fluent API
```csharp
modelBuilder.Entity<UserTask>()
    .HasOne(ut => ut.AssignedEmployee)
    .WithMany(u => u.AssignedTasks)
    .HasForeignKey(ut => ut.AssignedEmployeeId)
    .OnDelete(DeleteBehavior.Cascade);
```

### Blazor Server Interactive Components
```csharp
@page "/manager/tasks"
@layout UserDashboardLayout
@rendermode InteractiveServer
@inject ManageMateDBConetxt DbContext
```

### Cookie Authentication Configuration
```csharp
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
```

---

## Database Schema

### Users Table
| Column | Type | Constraints |
|--------|------|-------------|
| UserId | string | PK |
| Email | string | UNIQUE, NOT NULL |
| UserType | enum | TaskManager, Admin, Employee |
| Password | string | BCrypt hashed |
| Skills | string | JSON array |
| MinWorkingHours | int | Minimum daily requirement |

### Tasks Table
| Column | Type | Constraints |
|--------|------|-------------|
| TaskId | string | PK |
| Name | string | NOT NULL |
| Deadline | datetime | NOT NULL |
| Status | enum | UnAssigned→Reviewed |
| SkillsNeeded | string | Required competencies |

---

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- MySQL 8.0+
- Code editor (VS 2022 / Rider / VS Code)

### Setup

1. **Clone and restore**
   ```bash
   dotnet restore
   ```

2. **Configure database connection** (`appsettings.json`)
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=managemate;User=root;Password=yourpassword;"
     }
   }
   ```

3. **Run migrations**
   ```bash
   dotnet ef database update
   ```

4. **Build and run**
   ```bash
   dotnet run
   ```

5. **Access the application**
   - URL: `https://localhost:7000`
   - Login/Signup at `/auth/login`

---

## .NET Ecosystem Skills Demonstrated

| Skill | Implementation |
|-------|-----------------|
| **Blazor Server** | InteractiveServer rendering, lifecycle methods, state management |
| **EF Core** | Code-first migrations, Fluent API, relationship configuration |
| **Dependency Injection** | `AddDbContext`, service registration, `@inject` |
| **Authentication** | Cookie auth, claims-based identity, policy authorization |
| **Configuration** | `appsettings.json`, environment-based config |
| **Routing** | Attribute routing, role-based route guards |
| **Component Architecture** | Layouts, parameters, cascading values |
| **Validation** | DataAnnotations, model validation |
| **Logging & Error Handling** | Middleware, exception handler pages |

---

## Security Best Practices

- BCrypt password hashing (not plain MD5/SHA)
- Parameterized EF Core queries (no SQL injection)
- Antiforgery tokens enabled
- HTTPS enforcement
- Role-based authorization
- Environment-based error handling

---

## License

This project is for demonstration purposes.

---

**Built with ❤️ using .NET 9.0 and Blazor Server**
