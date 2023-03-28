using KnowledgeBase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using KnowledgeBase.Data;
using System.Drawing.Drawing2D;

namespace KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        

        public IActionResult Index()
        {
            var documents = _context.Documents.ToList();
            ViewBag.Category = _context.Categories.ToList();
            //ViewBag.Department = _context.Departments.ToList();

            return View(documents);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Department = _context.Departments.ToList();
            ViewBag.Laws = _context.Laws.ToList();
            //ViewData["Laws"] = new SelectList(_context.Laws, "Id", "Title");
            return View();
            
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, CategoryId, DepartmentId, Laws, Text, File, FileId")] Document document, int[] Laws, List<IFormFile> files)
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
                //await _context.SaveChangesAsync();
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
                            //fileModel.Title = file.FileName;
                            fileModel.Title = Path.GetFileNameWithoutExtension(file.FileName);
                            fileModel.Extension = Path.GetExtension(file.FileName);
                            string wwwrootpath = _webHostEnvironment.WebRootPath;
                            //https://localhost:7233/Documents/DownloadFile?fileId=9
                            string subDirPath = $"{document.Id}";
                            DirectoryInfo dirInfo = new DirectoryInfo(wwwrootpath + "/files/");
                            if (!dirInfo.Exists)
                            {
                                dirInfo.Create();
                            }
                            dirInfo.CreateSubdirectory(subDirPath);
                            fileModel.Path = Path.Combine(Directory.GetCurrentDirectory(), wwwrootpath + "/files/" + subDirPath + "/", fileModel.Title+fileModel.Extension);
                            fileModels.Add(fileModel);
                            Debug.WriteLine("++===================++");
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
                //_context.Documents.Add(document);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
          
            return View(document);

        }
  





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}