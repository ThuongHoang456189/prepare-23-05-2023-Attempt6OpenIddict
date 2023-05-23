using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Attempt6OpenIddict.Web;

[Dependency(ReplaceServices = true)]
public class Attempt6OpenIddictBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Attempt6OpenIddict";
}
