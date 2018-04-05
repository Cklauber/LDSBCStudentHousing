using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StudentHousing.Identity
{
    public class StudentHousingUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<StudentHousingUser>
    {
        public StudentHousingUserClaimsPrincipalFactory(UserManager<StudentHousingUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(StudentHousingUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("Email", user.Email));
            identity.AddClaim(new Claim("PhoneNumber", user.PhoneNumber));
            return identity;
        }
    }
}
