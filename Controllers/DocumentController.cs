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

namespace KnowledgeBase.Controllers
{
    public class DocumentController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: DocumentController

      

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> DownloadFile(long fileId)
        {
            var file = await _context.Files.FindAsync(fileId);

            if (file != null)
            {
                var stream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
                return File(stream, file.Extension, file.Title);
            }

            return NotFound();
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

           
            //if (document != null)
            //{
            //    document.Files = _context.Documents
            //                          .Where(d => d.Id == id)
            //                          .Select(d => d.Files)
            //                          .FirstOrDefault();
            //}
            //else
            //{ 
            //    return NotFound();
            //}
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentController1/Delete/5
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
