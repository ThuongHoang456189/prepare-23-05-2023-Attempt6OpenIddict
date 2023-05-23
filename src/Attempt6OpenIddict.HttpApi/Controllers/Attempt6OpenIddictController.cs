using Attempt6OpenIddict.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Attempt6OpenIddict.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Attempt6OpenIddictController : AbpControllerBase
{
    protected Attempt6OpenIddictController()
    {
        LocalizationResource = typeof(Attempt6OpenIddictResource);
    }
}
