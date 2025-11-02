**HotelBooking.API**

A RESTful API for hotel booking management, built using ASP.NET Core, Entity Framework, and SQL Server. This project provides a modular backend foundation for hotel reservation systems, including core booking logic, infrastructure setup, and database integration.

📦 Project Structure

The solution is organized into four main components:

    • HotelBooking.API – ASP.NET Core Web API project exposing endpoints for hotel booking operations.
    • HotelBooking.BusinessLogicLayer – Contains dto, interfaces, and business logic.
    • HotelBooking.DataAccessLayer – Implements data access using Entity Framework Core.
    • Sql – SQL scripts for database schema and seed data.

    📁 Project Details
This application has the following  end points

-   Reset Database tables -  //api/Hotel/reset
-   Seed Database - //api/Hotel/seed
-   Get all Hotel -  //api/Hotel
-   Get Hotel By Name - //api/Hotel/find/{name}
-   Get Rooms availablity for a Hotel - //api/Hotel/availability
-   Book a Room - //api/Hotel/book [POST]
-   Get Booking details -  //api/Hotel/booking/{reference}


<img width="1866" height="831" alt="image" src="https://github.com/user-attachments/assets/b9f43185-9313-4c25-9bec-3987aa041b80" />
