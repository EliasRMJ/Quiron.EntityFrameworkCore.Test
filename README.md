# Quiron.EntityFrameworkCore.Test
In order to speed up the development of more robust systems, the 'Quiron.EntityFrameworkCore' package was created. With all the resources provided by it, you will focus on the development of your business in the application, without losing on the creation of persistence methods and filters.

For this reason, a practical example of how to use the package in a very detailed way was created, from simple to more complex examples.

# Actions begin
- [x] Create a new DB in your SQL Server instance with the name 'Quiron.EntityFrameworkCore.Test' and change the connection string in the appsettings.json file to point to your DB.
- [x] Execute migrations to create the database structure. The migrations are already created in the project, so you don't need to worry about creating them. Just execute the command below to create the database structure.

# Commands for begin the tests
- [x] dotnet ef migrations add StartMigration --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test
- [x] dotnet ef database update --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test

# Features
- **Unit of Work**: The package implements the Unit of Work pattern, allowing you to manage multiple repositories and transactions in a single context.
- **Repository**: The package provides a generic repository implementation, allowing you to perform CRUD operations on your entities easily.
- **Filters**: The package allows you to define filters for your entities, enabling you to apply common filtering logic across multiple queries.
- **Asynchronous Operations**: The package provides asynchronous methods for all repository operations, allowing you to take advantage of the async/await pattern in your applications.
- **Customizable**: The package is designed to be easily extensible, allowing you to customize the behavior of the repositories and filters to fit your specific needs.
- **Logging**: The package provides built-in logging support, allowing you to log all database operations and filter queries for debugging and auditing purposes.
- **Validation**: The package provides built-in validation support, allowing you to validate your entities before saving them to the database.
- **Caching**: The package provides built-in caching support, allowing you to cache the results of your queries for improved performance.
- **Transactions**: The package provides built-in transaction support, allowing you to perform multiple database operations in a single transaction.
- **Concurrency Control**: The package provides built-in concurrency control support, allowing you to handle concurrent updates to your entities.
- **Change Tracking**: The package provides built-in change tracking support, allowing you to track changes to your entities and automatically update the database.
- **Auditing**: The package provides built-in auditing support, allowing you to track changes to your entities and log them for auditing purposes.
- **Soft Deletes**: The package provides built-in soft delete support, allowing you to mark entities as deleted without actually removing them from the database.
- **Bulk Operations**: The package provides built-in bulk operation support, allowing you to perform bulk inserts, updates, and deletes on your entities for improved performance.
- **Batch Processing**: The package provides built-in batch processing support, allowing you to process large amounts of data in batches for improved performance.
- **Data Seeding**: The package provides built-in data seeding support, allowing you to seed your database with initial data for testing and development purposes.
- **Migration Support**: The package provides built-in migration support, allowing you to manage database schema changes over time.
- **Custom Conventions**: The package provides built-in support for custom conventions, allowing you to define your own naming conventions and mapping rules for your entities.
- **Custom Mappings**: The package provides built-in support for custom mappings, allowing you to define your own mapping rules for your entities.
- **Custom Validation**: The package provides built-in support for custom validation, allowing you to define your own validation rules for your entities.
- **Custom Filters**: The package provides built-in support for custom filters, allowing you to define your own filtering rules for your entities.
- **Custom Logging**: The package provides built-in support for custom logging, allowing you to define your own logging rules for your entities.