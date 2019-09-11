using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace JWTExample.MVC
{
    public class ApplicationUser : ClaimsPrincipal
    {
        public ApplicationUser(IEnumerable<Claim> claims)
            : base(new ClaimsIdentity(claims))
        {

        }

        public string Name => FindFirst(ClaimTypes.Name)?.Value?.ToString();
        public long Id => long.Parse(FindFirst(ClaimTypes.NameIdentifier)?.Value?.ToString() ?? "-1");
        public DateTime LastLogin => DateTime.Parse(FindFirst("LastLogin")?.Value?.ToString() ?? DateTime.MinValue.ToString());
    }
}