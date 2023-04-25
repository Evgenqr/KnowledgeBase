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
       // public async IActionResult Index(int? id)
          public async Task<IActionResult> Index(int id)
        {
            if (id < 1 || _context.Documents == null)
            {
                return NotFound();
            }

            var law = await _context.Laws.FindAsync(id);
            if (law == null)
            {
                return NotFound();
            }
            var documents = await _context.Documents
                                   .Include(d => d.Laws)
                                   .Where(d => d.Laws.Contains(law))
                                   .ToListAsync();
            ViewBag.Laws = _context.Laws.FirstOrDefault(l => l.Id == id)?.shorttitle;
            ViewBag.Category = _context.Categories.ToList();
            return View(documents);
        }
    }
}