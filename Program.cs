using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Caching.Memory;
using Quiron.EntityFrameworkCore.Constants;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;
using Quiron.EntityFrameworkCore.Test.Domain.Repositorys;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.AppServices;
using Quiron.EntityFrameworkCore.Test.Domain.Mapper;
using Quiron.EntityFrameworkCore.CrossCutting.Logging;
using Quiron.EntityFrameworkCore.Test.Middleware;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Transaction;
using Quiron.EntityFrameworkCore.MessagesProvider.Locations;
using Quiron.EntityFrameworkCore.MessagesProvider;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ContextTest>(options => {
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("connName"),
        b => b.MigrationsAssembly("Quiron.EntityFrameworkCore.Test")
    );
});
builder.Services.AddSingleton(typeof(IDatabaseContext), typeof(ContextTest));

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<Messages, MessagesEnUs>();
builder.Services.AddSingleton<MessagesEnUs>();
builder.Services.AddSingleton<MessagesPtBr>();

builder.Services.AddSingleton<IMessagesProvider, MessagesProvider>();

builder.Services.AddScoped(typeof(ITransactionWork), typeof(TransactionWork));

builder.Services.AddScoped(typeof(IClassificationRepository), typeof(ClassificationRepository));
builder.Services.AddScoped(typeof(IClassificationService), typeof(ClassificationService));
builder.Services.AddScoped(typeof(IClassificationAppService), typeof(ClassificationAppService));

builder.Services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));
builder.Services.AddScoped(typeof(IClientService), typeof(ClientService));
builder.Services.AddScoped(typeof(IClientAppService), typeof(ClientAppService));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new FileLoggerProvider("Logs"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Quiron.EntityFrameworkCore.Test",
        Description = "APIs - Component responsible for managing data persistence.",
        Contact = new() { Name = "Quiron.EntityFrameworkCore.Test", Email = "text@Quiron.EntityFrameworkCore.test.com.br", Url = new Uri("https://Quiron.EntityFrameworkCore.test.com.br") }
    });
});
builder.Services.AddApiVersioning(option =>
{
    option.ReportApiVersions = true;
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

#region Swagger - Simple Test - Classification  
app.MapPost("classifications/createorreplace", async (
    IClassificationAppService classificationAppService,
    ClassificationViewModel classification) =>
{
    var operationReturn = await classificationAppService.CreateOrUpdateAsync(classification);

    return operationReturn.IsSuccess ? Results.Ok(operationReturn) : Results.BadRequest(operationReturn);
})
.Produces<OperationReturn>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("PostClassification")
.WithTags("Classification");

app.MapGet("classifications/{id}", async (
    int id,
    IClassificationAppService classificationAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Classification", ReturnType = ReturnTypeEnum.Empty, Key = $"{id}", Field = "id" };

    try
    {
        return Results.Ok(await classificationAppService.GetEntityByIdAsync(id));
    }
    catch(Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClassificationViewModel>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClassification")
.WithTags("Classification");

app.MapGet("classifications/{page}/{pageSize}/descriptions/{name}", async (
    int page,
    int pageSize,
    string name,
    IClassificationAppService classificationAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Classification", ReturnType = ReturnTypeEnum.Empty, Key = $"{name}", Field = "name" };

    try
    {
        return Results.Ok(await classificationAppService.Filter(find => find.Name!.Contains(name) && find.Active == ActiveEnum.S, page, pageSize));
    }
    catch (Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClassificationViewModel[]>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClassificationForName")
.WithTags("Classification");

app.MapGet("classifications/{page}/{pageSize}", async (
    int page,
    int pageSize,
    IClassificationAppService classificationAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Classification", ReturnType = ReturnTypeEnum.Empty };

    try
    {
        return Results.Ok(await classificationAppService.Paginate(page, pageSize));
    }
    catch (Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClassificationViewModel[]>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClassificationAll")
.WithTags("Classification");
#endregion

#region Swagger - Complex Test - Client
app.MapPost("clients/create", async (
    IClientAppService cliebtAppService,
    ClientViewModel clientViewModel) =>
{
    var operationReturn = await cliebtAppService.CreateAsync(clientViewModel);
    return operationReturn.IsSuccess ? Results.Ok(operationReturn) : Results.BadRequest(operationReturn);
})
.Produces<OperationReturn>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("PostClient")
.WithTags("Clients");

app.MapPut("{id}/clients/update", async (
    long id,
    IClientAppService cliebtAppService,
    ClientViewModel clientViewModel) =>
{
    clientViewModel.ClientId = id;
    var operationReturn = await cliebtAppService.UpdateAsync(clientViewModel);
    return operationReturn.IsSuccess ? Results.Ok(operationReturn) : Results.BadRequest(operationReturn);
})
.Produces<OperationReturn>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("PutClient")
.WithTags("Clients");

app.MapGet("clients/{id}", async (
    int id,
    IClientAppService clientAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Client", ReturnType = ReturnTypeEnum.Empty, Key = $"{id}", Field = "id" };

    try
    {
        return Results.Ok(await clientAppService.GetEntityByIdAsync(id));
    }
    catch (Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClientViewModel>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClient")
.WithTags("Clients");

app.MapGet("clients/{page}/{pageSize}/names/{name}", async (
    int page,
    int pageSize,
    string name,
    IClientAppService clientAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Client", ReturnType = ReturnTypeEnum.Empty, Key = $"{name}", Field = "name" };

    try
    {
        return Results.Ok(await clientAppService.Filter(find => find.Name!.Contains(name) && find.Active == ActiveEnum.S, page, pageSize));
    }
    catch (Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClientViewModel[]>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClientForName")
.WithTags("Clients");

app.MapGet("clients/{page}/{pageSize}/{begin}/{end}/period", async (
    int page,
    int pageSize,
    DateTime begin,
    DateTime end,
    IClientAppService clientAppService) =>
{
    OperationReturn operationReturn = new() { EntityName = "Client", ReturnType = ReturnTypeEnum.Empty, Key = $"{begin} e {end}", Field = "begin|end" };

    try
    {
        return Results.Ok(await clientAppService.Filter(find => find.InclusionDate >= begin && 
                                                                find.InclusionDate <= end
                                                        , page, pageSize));
    }
    catch (Exception ex)
    {
        operationReturn.Messages.Add(new() { ReturnType = ReturnTypeEnum.Empty, Code = Codes._WARNING, Text = ex.Message });
    }

    return Results.BadRequest(operationReturn);
})
.Produces<ClientViewModel[]>(StatusCodes.Status200OK)
.Produces<OperationReturn>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("GetClientForPeriod")
.WithTags("Clients");
#endregion

app.Run();