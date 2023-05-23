using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Attempt6OpenIddict.Data;
using Volo.Abp.DependencyInjection;

namespace Attempt6OpenIddict.EntityFrameworkCore;

public class EntityFrameworkCoreAttempt6OpenIddictDbSchemaMigrator
    : IAttempt6OpenIddictDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAttempt6OpenIddictDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the Attempt6OpenIddictDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Attempt6OpenIddictDbContext>()
            .Database
            .MigrateAsync();
    }
}
