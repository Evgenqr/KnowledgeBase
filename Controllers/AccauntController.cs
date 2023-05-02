using KnowledgeBase.Data;
using Microsoft.AspNetCore.Mvc;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;

namespace KnowledgeBase.Controllers
{
      public class AccauntController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccauntController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (IsValidUserAndPassword(model.NickName, model.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.NickName),
                        new Claim(ClaimTypes.Role, model.Role.ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    Debug.WriteLine(" +++++++++++++++++++++++++ " + model.Role);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Debug.WriteLine($"----- {model.Role}-------{model.NickName}-------{model.Password}---------");
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private bool IsValidUserAndPassword(string NickName, string password)
        {
            // Implement your authentication logic here, for example:
            //var user12 = GetUser(userName);
            var user = _context.Users
                .Where(u => u.NickName == NickName)
                .Include(u => u.Password)
                .Include(u => u.Role)
                .FirstOrDefault();
            Debug.WriteLine(user.Role + "+++++==========" + user.NickName);
            return user != null && user.Password == password;
        }

        //private User GetUser(string userName)
        //{
        //    // Implement your user retrieval logic here, for example:
        //    return new User
        //    {
        //        Id = 1,
        //        NickName = "Alice",
        //        Password = "Password123",
        //        Role = Role.Administrator
        //    };
        //}

    }
}
