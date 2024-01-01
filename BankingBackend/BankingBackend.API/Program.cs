using BankingBackend.API.Extensions;
using BankingBackend.Application;
using BankingBackend.Persistence;
using BankingBackend.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();

builder.Services.ConfigureApplication();
builder.Services.ConfigurePersistence(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetService<DataContext>();
    dataContext?.Database.EnsureCreated();

    scope.ServiceProvider.UpdateDatabase();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseErrorHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
