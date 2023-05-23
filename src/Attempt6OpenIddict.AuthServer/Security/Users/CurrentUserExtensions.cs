using Volo.Abp.Users;

namespace Attempt6OpenIddict.Security.Users
{
    public static class CurrentUserExtensions
    {
        public static string GetCustomThuong(this ICurrentUser currentUser)
        {
            return currentUser.FindClaimValue("CustomThuong");
        }
    }
}
