using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Database;

public class BackendDbContextFactory : IDesignTimeDbContextFactory<BackendDbContext>
{
    public BackendDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BackendDbContext>().UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=postgres")
            .Options;

        return new BackendDbContext(options);
    }
}