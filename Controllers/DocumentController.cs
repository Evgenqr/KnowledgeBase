using KnowledgeBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using KnowledgeBase.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;
using System.Diagnostics;
using System.Xml.Linq;

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
        public ActionResult Cancel(int id)
        {
            // Получение информации о записи
            var document = _context.Documents.Find(id);
            // Если запись не найдена, перенаправляем на страницу ошибки
            if (document == null)
            {
                return RedirectToAction("Error", "Home");
            }
            // Перенаправляем на предыдущую страницу
            return RedirectToAction("Details", new { id = document.Id });
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

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Department = _context.Departments.ToList();
            ViewBag.Laws = _context.Laws.ToList();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, CategoryId, DepartmentId, Laws, Text, File, FileId")] Models.Document document, int[] Laws, List<IFormFile> files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    document.DateCreate = DateTime.UtcNow;
                    List<Law> selectedLaws = new List<Law>();
                    if (Laws != null)
                    {
                        foreach (int lawId in Laws)
                        {
                            Law law = await _context.Laws.FindAsync(lawId);
                            if (law != null)
                            {
                                selectedLaws.Add(law);
                            }
                        }
                    }
                    document.Laws = selectedLaws;
                }
                _context.Add(document);
                await _context.SaveChangesAsync();
                if (files != null)
                {
                    var fileModels = new List<FileModel>();
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileModel = new FileModel();
                            fileModel.Title = Path.GetFileNameWithoutExtension(file.FileName);
                            fileModel.Extension = Path.GetExtension(file.FileName);
                            string wwwrootpath = _webHostEnvironment.WebRootPath;
                            string subDirPath = $"{document.Id}";
                            DirectoryInfo dirInfo = new DirectoryInfo(wwwrootpath + "/files/");
                            if (!dirInfo.Exists)
                            {
                                dirInfo.Create();
                            }
                            dirInfo.CreateSubdirectory(subDirPath);
                            fileModel.Path = Path.Combine(Directory.GetCurrentDirectory(), wwwrootpath + "/files/" + subDirPath + "/", fileModel.Title + fileModel.Extension);
                            fileModels.Add(fileModel);
                            using (var fileStream = new FileStream(fileModel.Path, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                    // Связываем файлы с документом
                    document.Files = fileModels;
                }
                // Сохраняем документ в базе данных
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = document.Id });
                // return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                // return RedirectToAction("Index", "Home");
            }

            return View(document);

        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }
            var document = await _context.Documents.FindAsync(id);
            
            if (document == null)
            {
                return NotFound();
            }
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Department = _context.Departments.ToList();
            ViewBag.Laws = _context.Laws.ToList();
            ViewBag.Files = _context.Files.ToList();
            
            //ViewBag.Files = document.Files;
            return View(document);
        }

        // POST: Documents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,CategoryId,Laws,DepartmentId,Text, DateUpdate")] Models.Document document, int[] Laws, List<IFormFile> files)
        {
           
           
            if (id != document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalDocument = await _context.Documents.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
                    document.DateCreate = originalDocument.DateCreate;
                    //Debug.WriteLine("++++++++++++++++++", dateCreate);
                    Debug.WriteLine("=========--------", document.DateCreate);
                    document.DateUpdate = DateTime.UtcNow;
                    // Обновление поля Laws модели Document
                    var selectedLaws = HttpContext.Request.Form["selectedLaws"].ToString().Split(',');
                    document.Laws = new List<Law>();
                    foreach (var selectedLaw in selectedLaws)
                    {
                        if (!string.IsNullOrEmpty(selectedLaw))
                        {
                            var lawId = Convert.ToInt32(selectedLaw);
                            var law = await _context.Laws.FirstOrDefaultAsync(l => l.Id == lawId);
                            if (law != null)
                            {
                                document.Laws.Add(law);
                            }
                        }
                    }
                   // _context.Update(document);
                    _context.Entry(document).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = document.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
            }
            ViewBag.Files = document.Files;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", document.CategoryId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", document.DepartmentId);

            return View(document);
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