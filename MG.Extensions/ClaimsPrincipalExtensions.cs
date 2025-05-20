using System.Security.Claims;

namespace MG.Extensions.Session
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public static string GetUserName(this ClaimsPrincipal user)
            => user.Identity?.Name;

        public static string GetFullName(this ClaimsPrincipal user)
            => user.FindFirstValue("FullName");
    }

}