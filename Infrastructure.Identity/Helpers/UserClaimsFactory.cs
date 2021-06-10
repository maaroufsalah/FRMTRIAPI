using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Helpers
{
    public class UserClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public UserClaimsFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Nom ?? string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Prenom ?? string.Empty));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email ?? string.Empty));
            IList<string> roles = await this.UserManager.GetRolesAsync(user);
            foreach (var role in roles)
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            return identity;
        }
    }
}
