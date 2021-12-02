using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chopi.API.Models
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }

        public ClaimRequirementAttribute(string claimType, string[] claimValues) : base(typeof(ClaimRequirementFilter))
        {
            var claims = new object[claimValues.Length];
            
            for (int i = 0; i < claims.Length; i++)
            {
                claims[i] = new Claim(claimType, claimValues[i]);
            }

            Arguments = claims;
        }
    }
}
