namespace System.Security.Claims;
using static CinemaExperience.Infrastructure.Data.Constants.RoleConstants;

public static class ClaimsPrincipalExtensions
{
    public static string Id(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole(AdminRoleName);
    }

    public static bool IsCritic(this ClaimsPrincipal user)
    {
        return user.IsInRole(CriticRoleName);
    }
}
