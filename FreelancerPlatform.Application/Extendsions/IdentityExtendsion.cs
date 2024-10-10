using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Extendsions
{
	public static class IdentityExtendsion
	{
		public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
		{
			var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
				.Claims
				.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
			return int.Parse(claim.Value);
		}


        public static string GetFirstName(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
                .Claims
                .SingleOrDefault(x => x.Type == "firstName");
            return claim.Value;
        }
    }
}
