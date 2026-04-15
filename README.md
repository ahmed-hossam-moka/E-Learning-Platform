<div align="center">

# 🎓 Online Learning Platform

> *Empowering learners. Enabling educators. Elevating knowledge.*

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF_Core-Latest-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/ef/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-REST_API-0078D4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)

<br/>

![Platform Banner](https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=12&height=180&section=header&text=E-Learning%20Platform&fontSize=42&fontAlignY=35&desc=Built%20with%20ASP.NET%20Core%20%7C%20Clean%20Architecture&descAlignY=55&descAlign=50)

</div>

---

## 📖 Table of Contents

- [✨ About The Project](#-about-the-project)
- [⚡ Features](#-features)
- [🏗️ Architecture](#️-architecture)
- [📂 Project Structure](#-project-structure)
- [🛠️ Tech Stack](#️-tech-stack)
- [🚀 Getting Started](#-getting-started)
- [📡 API Endpoints](#-api-endpoints)
- [🗃️ Database Design](#️-database-design)
- [🤝 Contributing](#-contributing)

---

## ✨ About The Project

A full-featured, production-ready **E-Learning Management System** 
built on top of **ASP.NET Core** using a clean **3-Tier N-Layer Architecture**. 

Whether you are a student looking to enroll in courses, an instructor monetizing 
your knowledge, or an admin managing the ecosystem — EduVerse has you covered with 
a secure, scalable, and maintainable backend API.

> 💡 *This project was built with real-world design patterns, clean code principles,
> and industry-standard practices in mind.*

---

## ⚡ Features

<table>
  <tr>
    <td>

### 👥 User Management
- ✅ Multi-role system (Admin / Instructor / Student)
- ✅ JWT-based Authentication & Authorization
- ✅ Profile management per role

### 📚 Course Ecosystem
- ✅ Course CRUD with category organization
- ✅ Lecture management with attachments
- ✅ Lecture progress tracking per student

### 🧠 Quiz System
- ✅ Dynamic quiz & question creation
- ✅ Multiple choice answers
- ✅ Automated result calculation & storage

  </td>
    <td>

### ⭐ Reviews & Ratings
- ✅ Students can review & rate courses
- ✅ Helps instructors improve content

### 🛡️ Data Integrity
- ✅ Soft Delete across all core entities
- ✅ Global exception handling middleware
- ✅ Paginated API responses

  </td>
  </tr>
</table>

---

## 🏗️ Architecture

This project follows a clean **3-Tier N-Layer Architecture** 
ensuring a strict separation of concerns:

```
┌─────────────────────────────────────────────────────────┐
│ CLIENT / FRONTEND                                       │
└───────────────────────────┬─────────────────────────────┘
                            │ HTTP Requests
┌───────────────────────────▼─────────────────────────────┐
│ 1- API LAYER (Presentation)                             │
│    Controllers • Middleware • Auth                      │
└───────────────────────────┬─────────────────────────────┘
                            │ Calls
┌───────────────────────────▼─────────────────────────────┐
│ 2- BUSINESS LOGIC LAYER (BLL)                           │
│    Managers • Services • DTOs                           │
└───────────────────────────┬─────────────────────────────┘
                            │ Reads / Writes
┌───────────────────────────▼─────────────────────────────┐
│ 3- DATA ACCESS LAYER (DAL)                              │
│    Repositories • EF Core • Configurations • Models     │
└───────────────────────────┬─────────────────────────────┘
                            │
                ┌───────────▼───────────┐
                │    SQL SERVER DB      │
                └───────────────────────┘
```

### 🔑 Design Patterns Used

| Pattern | Where Used |
|---|---|
| 🏛️ **Repository Pattern** | DAL Layer — abstracts database queries |
| 📦 **DTO Pattern** | BLL Layer — decouples API from domain models |
| 🏭 **Manager / Service Pattern** | BLL Layer — encapsulates business logic |
| 🔧 **Fluent API Configuration** | DAL Layer — entity relationship mapping |
| 🗑️ **Soft Delete Pattern** | DAL Layer — logical deletion with `ISoftDeletable` |
| 🛡️ **Middleware Pattern** | API Layer — global exception handling |

---

## 📂 Project Structure

```
📦 E-Learning-Platform/
┃
├── 📄 OnlineLearningPlatform.sln
├── 📄 .gitignore
┃
├── 📁 OnlineLearningPlatform.Api/ # 🌐 Presentation Layer
│ ├── 📁 Controllers/
│ │ ├── 🎮 AdminController.cs
│ │ ├── 🎮 CoursesController.cs
│ │ ├── 🎮 EnrollmentController.cs
│ │ ├── 🎮 LecturesController.cs
│ │ ├── 🎮 PaymentController.cs
│ │ ├── 🎮 QuizController.cs
│ │ ├── 🎮 ReviewsController.cs
│ │ ├── 🎮 WithdrawalsController.cs
│ │ ├── 📁 Auth/
│ │ └── 📁 Users/
│ ├── 📁 CustomExceptionMiddleware/
│ └── ⚙️ Program.cs
┃
├── 📁 OnlineLearningPlatform.BLL/ # ⚙️ Business Logic Layer
│ ├── 📁 Dtos/
│ │ ├── 📁 Auth/
| | |── 📁 Admin/
│ │ ├── 📁 Earnings/
| | ├── 📁 Quizzes/
│ │ ├── 📁 Reviews/
| | └── 📁 Users/
│ └── 📁 Managers/
│ ├── 🧩 CourseManager.cs
│ ├── 🧩 EnrollmentManager.cs
│ ├── 🧩 PaymentManager.cs
│ ├── 🧩 QuizManager.cs
│ └── ...more managers
┃
└── 📁 OnlineLearningPlatform.DAL/ # 🗄️ Data Access Layer
├── 📁 Models/
│ ├── 🏷️ Course.cs
| ├── 🏷️ Student.cs
│ ├── 🏷️ Instructor.cs
| ├── 🏷️ Quiz.cs
│ ├── 🏷️ Payment.cs
| ├── 🏷️ Enrollment.cs
│ └── ...more models
├── 📁 Repository/d
├── 📁 Configuration/
├── 📁 DataBase/
│   └── 🗃️ PlatformContext.cs
└── 📁 Migrations/
```

---

## 🛠️ Tech Stack

<div align="center">

| Category | Technology |
|---|---|
| **Framework** | ASP.NET Core 8 |
| **ORM** | Entity Framework Core |
| **Database** | Microsoft SQL Server |
| **Authentication** | ASP.NET Core Identity + JWT Bearer |
| **API Style** | RESTful API |
| **Architecture** | 3-Tier N-Layer |
| **Patterns** | Repository, DTO, Soft Delete, Middleware |
| **Migration Tool** | EF Core Migrations |

</div>

---

## 🚀 Getting Started

### ✅ Prerequisites

- .NET 8.0 SDK  
- SQL Server (or Express)  
- Visual Studio 2022 / VS Code  
- Git  

---

### 📥 Installation

**1. Clone the repository**
```bash
git clone https://github.com/yourusername/E-Learning-Platform.git
cd E-Learning-Platform
```

**2. Configure the database connection**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=EduVerseDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YOUR_SUPER_SECRET_KEY_HERE",
    "Issuer": "EduVersePlatform",
    "Audience": "EduVerseUsers"
  }
}
```

**3. Apply migrations**
```bash
dotnet ef database update --project OnlineLearningPlatform.DAL --startup-project OnlineLearningPlatform.Api
```

**4. Run the app**
```bash
dotnet run --project OnlineLearningPlatform.Api
```

**5. Open Swagger**
```
https://localhost:7000/swagger
```

🎉 You're all set!

---

## 📡 API Endpoints

| Module | Method | Endpoint | Description |
|---|---|---|---|
| 🔐 Auth | POST | /api/auth/register | Register user |
| 🔐 Auth | POST | /api/auth/login | Login |
| 📚 Courses | GET | /api/courses | Get courses |
| 📚 Courses | POST | /api/courses | Create course |
| 🎓 Enrollment | POST | /api/enrollment | Enroll |
| 🧠 Quiz | GET | /api/quiz/{id} | Get quiz |
| 💳 Payment | POST | /api/payment | Pay |
| ⭐ Reviews | POST | /api/reviews | Add review |
| 💰 Earnings | GET | /api/earnings | Instructor earnings |
| 🏧 Withdrawal | POST | /api/withdrawals | Withdraw |

---

## 🗃️ Database Design

```
ApplicationUser ──┬── Student ────── Enrollment ─── Course
                  │                               ─── Payment
                  │                               ─── Review
                  │                               ─── UserLectureProgress
                  │
                  └── Instructor ─── Course ──┬── Lecture ─── LectureAttachment
                                              ├── Category
                                              ├── Quiz ──── Question ─── AnswerChoice
                                              └── Earnings
                                              
Admin ──── Announcements
       └── Notifications
```

---

## 🤝 Contributing

```
1. Fork
2. Create branch (feature/AmazingFeature)
3. Commit
4. Push
5. Open PR
```
<div align="center">
<img src="https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=6,11,20&height=100&section=footer" width="100%"/>
⭐ If you like this project, give it a star!

</div>

