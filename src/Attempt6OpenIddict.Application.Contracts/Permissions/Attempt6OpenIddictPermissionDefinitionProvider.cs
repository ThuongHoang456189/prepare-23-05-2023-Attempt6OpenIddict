using Attempt6OpenIddict.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Attempt6OpenIddict.Permissions;

public class Attempt6OpenIddictPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(Attempt6OpenIddictPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(Attempt6OpenIddictPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<Attempt6OpenIddictResource>(name);
    }
}
