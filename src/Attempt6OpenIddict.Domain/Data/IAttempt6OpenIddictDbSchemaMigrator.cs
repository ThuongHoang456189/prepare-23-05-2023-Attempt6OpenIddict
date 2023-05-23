using System.Threading.Tasks;

namespace Attempt6OpenIddict.Data;

public interface IAttempt6OpenIddictDbSchemaMigrator
{
    Task MigrateAsync();
}
