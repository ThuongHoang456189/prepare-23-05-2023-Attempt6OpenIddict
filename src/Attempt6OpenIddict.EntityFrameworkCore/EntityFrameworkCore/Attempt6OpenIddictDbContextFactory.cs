using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Attempt6OpenIddict.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class Attempt6OpenIddictDbContextFactory : IDesignTimeDbContextFactory<Attempt6OpenIddictDbContext>
{
    public Attempt6OpenIddictDbContext CreateDbContext(string[] args)
    {
        Attempt6OpenIddictEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<Attempt6OpenIddictDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new Attempt6OpenIddictDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Attempt6OpenIddict.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
