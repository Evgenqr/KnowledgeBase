using KnowledgeBase.Data;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class AccauntController : Controller
    {

        private readonly ApplicationDbContext _context;



        public AccauntController(ApplicationDbContext context) 
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
