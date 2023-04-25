using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Controllers
{
    

    public class LawsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LawsController (ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: LawController1
         public IActionResult Index(int id)
        {
            var law = _context.Laws.Find(id);
            if (id < 1 || _context.Documents == null || law == null)
            {
                return NotFound();
            }
            var documents =  _context.Documents
                                  .Include(d => d.Laws)
                                  .Where(d => d.Laws.Contains(law))
                                  .OrderByDescending(d => d.DateCreate)
                                  .ThenBy(d => d.Id)
                                  .ToList();
            ViewBag.Laws = _context.Laws.FirstOrDefault(l => l.Id == id)?.shorttitle;
            ViewBag.Category = _context.Categories.ToList();
            return View(documents);

        }
    }
}