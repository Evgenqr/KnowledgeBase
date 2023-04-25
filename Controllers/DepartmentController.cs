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
            var department = _context.Departments.Find(id);
            if (id < 1 || _context.Departments == null || department == null)
            {
                return NotFound();
            }
           
  
            var documents = _context.Documents
                .Include(c => c.Category)
                .Where(d => d.DepartmentId == id)
                .OrderByDescending(d => d.DateCreate)
               .ThenBy(d => d.Id);
            ViewBag.Departments = _context.Departments.FirstOrDefault(d => d.Id == id)?.Title;
            ViewBag.Documents = documents;
            ViewBag.Categories = _context.Categories.ToList();
            return View(documents);
        }
    }
}
