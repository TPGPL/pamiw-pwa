using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;

namespace pamiw_pwa.Security;

public static class Policies
{

    public const string IsUserLog = "IsUserLog";

    public static AuthorizationPolicy IsUserLogged()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    }
}
