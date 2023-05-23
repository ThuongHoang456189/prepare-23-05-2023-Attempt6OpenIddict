using Volo.Abp.Modularity;

namespace Attempt6OpenIddict;

[DependsOn(
    typeof(Attempt6OpenIddictApplicationModule),
    typeof(Attempt6OpenIddictDomainTestModule)
    )]
public class Attempt6OpenIddictApplicationTestModule : AbpModule
{

}
