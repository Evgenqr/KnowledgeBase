using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace KnowledgeBase.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        // GET: RoleController1
        public IActionResult Index()
        {
            //var roles = _roleManager.Roles;
            var users = _userManager.Users;
            return View(users);
        }

        // GET: RoleController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: RoleController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: RoleController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
