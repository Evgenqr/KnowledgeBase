using KnowledgeBase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Controllers
{
    public class LawsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}