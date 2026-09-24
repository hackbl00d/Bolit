using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace Backend.Database;

public class BackendDbContextFactory : IDesignTimeDbContextFactory<BackendDbContext>
{
    public BackendDbContext CreateDbContext(string[] args)
    {
        var secretPath = "/run/secrets/backend_env";
        if (File.Exists(secretPath))
        {
            Env.Load(secretPath);
        }

        else
        {
            Env.Load("../../.env");
        }

        string host =  Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
        string port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
        string  database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "my_db";
        string username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "normal_user";
        string  password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "normal_password";

        var options = new DbContextOptionsBuilder<BackendDbContext>()
            .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}")
            .Options;

        return new BackendDbContext(options);
    }
}