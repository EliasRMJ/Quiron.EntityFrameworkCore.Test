# Quiron.EntityFrameworkCore.Test
In order to speed up the development of more robust systems, the 'Quiron.EntityFrameworkCore' package was created. With all the resources provided by it, you will focus on the development of your business in the application, without losing on the creation of persistence methods and filters.

For this reason, a practical example of how to use the package in a very detailed way was created, from simple to more complex examples.

# Actions begin
- [x] Create a new DB in your SQL Server instance with the name 'Quiron.EntityFrameworkCore.Test' and change the connection string in the appsettings.json file to point to your DB.
- [x] Execute migrations to create the database structure. The migrations are already created in the project, so you don't need to worry about creating them. Just execute the command below to create the database structure.

# Commands for begin the tests
- [x] dotnet ef migrations add StartMigration --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test
- [x] dotnet ef database update --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test
