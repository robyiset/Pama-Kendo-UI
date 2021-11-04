using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;

namespace Kendo_UI_MVC.Services
{
    public class Cookies
    {
        public ClaimsPrincipal UserCookie( string username)
        {
            List<Claim> claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, "user"),
                    };
            ClaimsIdentity identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }
    }
}

