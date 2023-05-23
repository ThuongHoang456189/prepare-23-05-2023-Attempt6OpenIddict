using Attempt6OpenIddict.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Attempt6OpenIddict;

[DependsOn(
    typeof(Attempt6OpenIddictEntityFrameworkCoreTestModule)
    )]
public class Attempt6OpenIddictDomainTestModule : AbpModule
{

}
