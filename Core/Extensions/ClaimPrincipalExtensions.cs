using Core.Entites;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
namespace Core.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            //claimsPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;

            ClaimsPrincipal currentUser = ClaimsPrincipal.Current;
            if (currentUser.Identity.IsAuthenticated)
            {
                // User is authenticated
                IEnumerable<Claim> claims = currentUser.Claims;
                if (claims == null)
                {
                    // No claims were provided for the user
                }
                else
                {
                    // Use the claims as needed
                }
            }
            else
            {
                // User is not authenticated
            }
            IEnumerable<Claim> claimss = currentUser.Claims;
            //var claim = identity.Claims.Where(c => c.Type == claimType).ToList();
            var result = currentUser?.FindAll(claimType)?.Select(x => x.Value).ToList();

            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
