using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace Backend.Database;

public class BackendDbContextFactory : IDesignTimeDbContextFactory<BackendDbContext>
{
    public BackendDbContext CreateDbContext(string[] args)
    {
        Env.Load("../../");

        string host =  Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        string  database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "my_db";
        string username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "normal_user";
        string  password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "normal_password";

        var options = new DbContextOptionsBuilder<BackendDbContext>()
            .UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}")
            .Options;

        return new BackendDbContext(options);
    }
}