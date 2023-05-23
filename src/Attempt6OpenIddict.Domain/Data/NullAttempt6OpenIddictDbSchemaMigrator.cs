using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Attempt6OpenIddict.Data;

/* This is used if database provider does't define
 * IAttempt6OpenIddictDbSchemaMigrator implementation.
 */
public class NullAttempt6OpenIddictDbSchemaMigrator : IAttempt6OpenIddictDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
