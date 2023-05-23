using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Attempt6OpenIddict.Security.Users
{
    public class SrasClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
    {
        public Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
        {
            var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
            var userId = identity?.FindUserId();
            if (userId.HasValue)
            {
                identity?.AddClaim(new Claim("CustomThuong", "hello"));
            }

            return Task.CompletedTask;
        }
    }
}
