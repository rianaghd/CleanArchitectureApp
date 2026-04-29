using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CleanArchitectureApp.Infrastructure.Data;

namespace CleanArchitectureApp.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=cleanarchitecturedb;Username=postgres;Password=Riana1380!"
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}