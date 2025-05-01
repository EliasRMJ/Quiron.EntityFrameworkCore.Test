<img src="https://api.nuget.org/v3-flatcontainer/quiron.entityframeworkcore/1.5.11/icon" alt="Quiron.EntityFrameworkCore" width="100px" />

| Package |  Version | Popularity |
| ------- | ----- | ----- |
| `Quiron.EntityFrameworkCore` | [![NuGet](https://img.shields.io/nuget/v/Quiron.EntityFrameworkCore.svg)](https://nuget.org/packages/Quiron.EntityFrameworkCore) | [![Nuget](https://img.shields.io/nuget/dt/Quiron.EntityFrameworkCore.svg)](https://nuget.org/packages/Quiron.EntityFrameworkCore) |


## What is the Quiron.EntityFrameworkCore?

To accelerate the development of more robust systems, the "Quiron.EntityFrameworkCore" package was created. With all the features offered and the best practices and methodology currently used, you will focus on developing your business in the application, without wasting time creating persistence methods and filters.

For this reason, a practical example of how to use the package in a very detailed way was created, from simple to more complex examples.

## Give a Star! ⭐

If you find this project useful, please give it a star! It helps us grow and improve the community.

## Installation

Install via NuGet:

```bash
dotnet add package Quiron.EntityFrameworkCore
```

## Actions begining

- ✅ Create a new DB in your SQL Server instance with the name 'Quiron.EntityFrameworkCore.Test' and change the connection string in the appsettings.json file to point to your DB.
- ✅ Execute migrations to create the database structure. The migrations are already created in the project, so you don't need to worry about creating them. Just execute the command below to create the database structure.

## Commands for begin the tests

- ✅ dotnet ef migrations add StartMigration --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test
- ✅ dotnet ef database update --context Quiron.EntityFrameworkCore.Test.Domain.ContextTest --startup-project Quiron.EntityFrameworkCore.Test

## Namespaces

- ✅ Quiron.EntityFrameworkCore
- ✅ Quiron.EntityFrameworkCore.AppServices
- ✅ Quiron.EntityFrameworkCore.CrossCutting
- ✅ Quiron.EntityFrameworkCore.Entitys
- ✅ Quiron.EntityFrameworkCore.Enuns
- ✅ Quiron.EntityFrameworkCore.Interfaces
- ✅ Quiron.EntityFrameworkCore.MessagesProvider
- ✅ Quiron.EntityFrameworkCore.MessagesProvider.Locations
- ✅ Quiron.EntityFrameworkCore.Repositorys
- ✅ Quiron.EntityFrameworkCore.Services
- ✅ Quiron.EntityFrameworkCore.Structs
- ✅ Quiron.EntityFrameworkCore.Transactions
- ✅ Quiron.EntityFrameworkCore.Validations

## Basic Usage

### Domain Entity

```csharp
using Quiron.EntityFrameworkCore.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{Name}")]
    [DisplayName("Classification")]
    [Table("Classification")]
    public class Classification : EntityTypeBase { }
}
```

### Repositorys Interface

```csharp
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;

namespace Quiron.EntityFrameworkCore.Test.Domain.Repositorys
{
    public interface IClassificationRepository : IRepositoryBase<Classification> { }
}
```

### Services Interface

```csharp
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;

namespace Quiron.EntityFrameworkCore.Test.Domain.Services
{
    public interface IClassificationService : IServiceBase<Classification>{ }
}
```

### AppServices Interface

```csharp
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public interface IClassificationAppService : IAppServiceBase<ClassificationViewModel>
    { 
        Task<OperationReturn> ChangeStatusAsync(long id, ActiveEnum status);
    }
}
```

### Validations

```csharp
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Validations.Interfaces;
using Quiron.EntityFrameworkCore.Validations;

namespace Quiron.EntityFrameworkCore.Test.Domain.Validations
{
    public class ClassificationValidation(IClientService clientService
                                        , IMyMessagesProvider messagesProvider)
        : ValidationBase<Classification>(messagesProvider), IClassificationValidation
    {
        public override async Task Validate(IElement element)
        {
            await base.Validate(element);

            if (this.IsValid)
            {
                var classification = element as Classification;

                if (classification!.Active == Enuns.ActiveEnum.N)
                {
                    var clients = await clientService.Filter(find => find.ClassificationId == classification.Id);
                    if (clients.Any())
                        _messages.Add(messagesProvider.MyCurrent.InvalidOperation);
                }
            }
        }
    }
}
```

## Features

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


## Compatibility

Supports:

- ✅ .NET Standard 2.1  
- ✅ .NET 9 through 9 (including latest versions)  
- ⚠️ Legacy support for .NET Core 3.1 and older (with limitations)
  
## About
Quiron.EntityFrameworkCore was developed by [EliasRMJ](https://www.linkedin.com/in/elias-medeiros-98232066/) under the [MIT license](LICENSE).
