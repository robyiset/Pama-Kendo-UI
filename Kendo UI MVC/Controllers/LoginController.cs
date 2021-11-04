using Kendo_UI_MVC.Models;
using Kendo_UI_MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kendo_UI_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Cookies cookie = new Cookies();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Validating(string username, string password)
        {
            if (username == "superuser" && password == "123123")
            {
                ClaimsPrincipal principal = cookie.UserCookie(username);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    RedirectUri = "/barang",
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(5)
                });
            }

            return RedirectToAction("Index", "barang");
        }
    }
}
