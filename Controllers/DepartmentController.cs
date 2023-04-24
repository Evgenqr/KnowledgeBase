using KnowledgeBase.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _context;
        public DepartmentController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var documents = _context.Documents
                .Include(c => c.Category)
                .Where(d => d.DepartmentId == id);
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Documents = documents;
            ViewBag.Categories = _context.Categories.ToList();
            return View(documents);
        }
    }
}
