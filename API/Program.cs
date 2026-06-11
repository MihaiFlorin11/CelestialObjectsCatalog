using Application.Abstraction;
using Infrastructure.Context;
using Infrastructure.Services;
using Infrastructure.Settings;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

// database container registration
builder.Services.AddScoped<DatabaseContext>();

// unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// configuration (options)
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

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
