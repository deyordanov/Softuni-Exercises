namespace TaskBoardApp.Extensions;

using System.Security.Claims;

public static class ClaimsPrincipalExtension
{
    public static string GetId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier)!;
    }
}