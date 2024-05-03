using System.Security.Claims;

namespace RealEstateProject.Extentions
{
    public static class ClaimPrincipalExtentions
    {
        public static string GetId(this ClaimsPrincipal user)
                        => user.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        //public static bool IsAdmin(this ClaimsPrincipal user)
        //   => user.IsInRole(Admin);
    }
}
