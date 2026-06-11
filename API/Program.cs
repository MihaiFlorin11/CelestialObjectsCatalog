using Application.Abstraction;
using Infrastructure.Context;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

var connectionString = builder.Configuration
    .GetSection(nameof(DatabaseSettings))
    .Get<DatabaseSettings>()?
    .ConnectionString;

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing.");
}

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();
