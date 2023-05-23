using System;
using System.Collections.Generic;
using System.Text;
using Attempt6OpenIddict.Localization;
using Volo.Abp.Application.Services;

namespace Attempt6OpenIddict;

/* Inherit your application services from this class.
 */
public abstract class Attempt6OpenIddictAppService : ApplicationService
{
    protected Attempt6OpenIddictAppService()
    {
        LocalizationResource = typeof(Attempt6OpenIddictResource);
    }
}
