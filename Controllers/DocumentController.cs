using KnowledgeBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;
using KnowledgeBase.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Build.Evaluation;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.Drawing.Drawing2D;

namespace KnowledgeBase.Controllers
{
    public class DocumentController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: DocumentController
        public IActionResult Index()
        {
            var documents = _context.Documents.ToList();
            ViewBag.Category = _context.Categories.ToList();
            return View(documents);
        }

        // GET: DocumentController/Details/5
        public ActionResult Details(long? id)
        {
           

            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }
            var document = _context.Documents
            .Where(d => d.Id == id)
            .Include(c => c.Category)
            .Include(o => o.Department)
            .Include(l => l.Laws)
            .Include(d => d.Files)
            .FirstOrDefault();
            ViewBag.Document = document;
            ViewBag.Files = document.Files;
            return View();
        }

        // GET: DocumentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentController1/Create
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

        // GET: DocumentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DocumentController1/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }
            var document = await _context.Documents
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("DeleteOk")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
              if (_context.Documents == null)
            {
                return Problem("Документ отсутствует.");
            }
           // var document = await _context.Documents.FindAsync(id);
            var document = await _context.Documents
            .Include(d => d.Files)
            .FirstOrDefaultAsync(d => d.Id == id);

            if (document != null)
            {
                var files = await _context.Files.Where(f => f.DocumentId == id).ToListAsync();
                foreach (var file in files)
                {
                    string wwwrootpath = _webHostEnvironment.WebRootPath;
                    string subDirPath = $"{document.Id}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), wwwrootpath + "/files/" + subDirPath);
                    if (Directory.Exists(path))
                    {
                       Directory.Delete(path, true);
                    }
                }
                _context.Documents.Remove(document);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool DocumentExists(long id)
        {
            return (_context.Documents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
