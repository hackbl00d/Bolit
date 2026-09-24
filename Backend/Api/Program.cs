using Backend.Api.Mappers;
using Backend.Api.Extensions;
using Backend.Api;
using Backend.Database;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var secretPath = "/run/secrets/backend_env";
if (File.Exists(secretPath))
{
    Env.Load(secretPath);
}

else
{
    Env.Load("../../.env");
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSingleton<DictionaryEntryMapper>();
builder.Services.AddDbContext<BackendDbContext>(options =>
{
    string host =  Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "postgres";
    string port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
    string  database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "my_db";
    string username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "normal_user";
    string  password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "normal_password";
    
    options.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");

});
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Services.SeedDictionaryEntries();

app.Run();

namespace Backend.Api
{
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
