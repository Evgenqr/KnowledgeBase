using KnowledgeBase.Data;
using Microsoft.AspNetCore.Mvc;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KnowledgeBase.Controllers
{
  
    public class AccauntController : Controller
    {

        private readonly ApplicationDbContext _context;
        

        public AccauntController(ApplicationDbContext context)
        {
            context = _context;
         
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User )
        {
            
            return View();
        }

    }
}
