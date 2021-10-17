using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreDepartman.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDepartman.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {

            return View();
        }
       
        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici==p.Kullanici && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Kullanici)
                };

                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);

                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Personel");
            }
            return View();
        }
           [HttpGet]
		public async Task<IActionResult> CikisYap()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("GirisYap", "Login");
		}
    }
}
