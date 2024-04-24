# 🎬 Cinema Experience

Welcome to the Cinema Experience repository! This MVC application is a hub for movie enthusiasts and critics to review and rate films, inspired by Rotten Tomatoes.

## 🌟 Features

- 🎥 View a list of movies with detailed information
- ✍️ Submit reviews as a user or critic, with separate ratings
- 🔍 Explore upcoming movies and keep an eye out for "The Next Big Thing".

## 🛠 Built With

- [ASP.NET Core 6.0](https://dotnet.microsoft.com/apps/aspnet) - The web framework used.
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Database service.
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Object-relational mapping framework.
- [Razor](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-6.0) - Template engine for UI.
- [ASP.NET Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio) - Identity management system.

## 🚀 How It Works

- Users can browse the movie database curated by administrators.
- Each film has a detailed page with descriptions, ratings, and reviews.
- Registered users can submit their own reviews and rate movies.
- Critics can provide expert reviews, influencing the critic score.
- Administrators manage the movie database and user roles.

## ⚙️ Application Configurations

Follow these steps to get your application up and running:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/your-username/cinema-experience.git
    ```
2. **Update your connection string** in the `appsettings.json` file to connect to your SQL Server instance.

3. **Update your database**:
    - Using Package Manager Console:
        ```powershell
        Update-Database
        ```
    - Using .NET Core CLI:
        ```bash
        dotnet ef database update
        ```

4. **Seeding sample data**:
would happen once you run the application, including Test Accounts:

- User: user@user.com / password: guest123456
- Critic: critic@critic.com / password: critic123456
- Admin: admin@admin.com / password: admin123456

5. **Run the application**:
    - Via Visual Studio: Use the IIS Express button.
    - Via .NET Core CLI:
        ```bash
        dotnet run
        ```

## 🔧 What You Need to Install
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/): IDE for .NET development.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads): Or use Docker Desktop to run a SQL Server container.
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet/6.0): The software development kit for .NET development.


## 🖼️Pictures:
![project](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/e3bd46d5-88b6-4eb7-a3e2-7fb568271ef8)
![image](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/65c7d140-f92c-4c54-a837-2c7f4e2179e6)
![image](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/d5439c67-8bae-403d-88ab-d15fa80c5089)
![image](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/bb359500-594a-4630-86ea-c40bfecfd1db)
![image](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/b16749e0-accc-413e-9e62-bb6cffad735c)
![image](https://github.com/BaiToshoo/CinemaExperience/assets/79370695/3b2965d4-02af-42e0-b509-4966a03827ce)
---

This project utilizes the best practices in web development and follows the MVC architectural pattern for a clean, maintainable, and scalable codebase.


