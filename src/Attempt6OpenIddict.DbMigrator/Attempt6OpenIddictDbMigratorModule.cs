using Attempt6OpenIddict.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Attempt6OpenIddict.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Attempt6OpenIddictEntityFrameworkCoreModule),
    typeof(Attempt6OpenIddictApplicationContractsModule)
    )]
public class Attempt6OpenIddictDbMigratorModule : AbpModule
{

}
