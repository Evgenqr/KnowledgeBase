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
