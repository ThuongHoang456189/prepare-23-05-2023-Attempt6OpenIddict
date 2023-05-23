using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Attempt6OpenIddict.Web.Pages;

public class IndexModel : Attempt6OpenIddictPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
