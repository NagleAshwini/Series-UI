# Series-UI

A comprehensive Web Management System built with **.NET Core**. This project demonstrates a **3-Tier Architecture** and incorporates **CQRS** for specialized data handling, such as Excel report generation.

## 🚀 Key Features
- **3-Tier Architecture:** Clear separation of concerns with dedicated layers for Data Access (DAL) and Business Logic (BAL).
- **CQRS Implementation:** Uses Command Query Responsibility Segregation for efficient Excel reporting and data queries.
- **Dynamic Frontend:** Integrated web pages using **JavaScript and AJAX** to interact with the API endpoints.
- **Reporting Services:** Built-in logic for generating and managing series reports.

## 🛠️ Tech Stack
- **Backend:** .NET Core (C#)
- **Database:** SQL Server 
- **Frontend:** HTML5, CSS3, JavaScript (AJAX)
- **Patterns:** 3-Tier Architecture, CQRS, MediatR

## 🏁 Getting Started
1. **Database:** Run the `Database_Setup_New.sql` script in your SQL Server instance.
2. **Configuration:** Update the connection string in `appsettings.json`.
3. **Run:** Open `SeriesUI.sln` in Visual Studio and press **F5**.
