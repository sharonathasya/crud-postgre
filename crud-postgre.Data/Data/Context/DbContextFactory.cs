using crud.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class MyDbContextFactory : IDesignTimeDbContextFactory<dbContext>
{
    public dbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<dbContext>();

        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=dbCrud;Username=postgres;Password=");

        return new dbContext(optionsBuilder.Options);
    }
}
