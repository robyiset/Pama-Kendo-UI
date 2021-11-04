using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

        //public ClaimsPrincipal PageCookie(string username, string role)
        //{
        //    List<Claim> claim = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, username),
        //        new Claim(ClaimTypes.Role, role)
        //    };
        //    ClaimsIdentity identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
        //    return new ClaimsPrincipal(identity);
        //}
    }
}

