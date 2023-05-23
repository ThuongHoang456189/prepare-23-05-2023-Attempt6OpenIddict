using Attempt6OpenIddict.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Attempt6OpenIddict.Web.Pages;

public abstract class Attempt6OpenIddictPageModel : AbpPageModel
{
    protected Attempt6OpenIddictPageModel()
    {
        LocalizationResourceType = typeof(Attempt6OpenIddictResource);
    }
}
