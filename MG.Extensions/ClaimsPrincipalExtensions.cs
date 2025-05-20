using System.Security.Claims;

namespace MG.Extensions.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
            => user.FindFirstValue("Uid") ?? 
            user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static string GetUserName(this ClaimsPrincipal user)
            => user.Identity?.Name;

        public static string GetFullName(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.Name) ??
               user.FindFirstValue("FullName") ??
               user.FindFirstValue("name") ?? string.Empty;

        public static string GetEmail(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.Email) ??
               user.FindFirstValue("email") ?? string.Empty;

        public static string GetRole(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.Role) ??
               user.FindFirstValue("role") ?? string.Empty;
    }

}