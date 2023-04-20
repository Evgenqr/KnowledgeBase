﻿using KnowledgeBase.Data;
using KnowledgeBase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        // GET: HomeController1
        public ActionResult Index(int idCat, long? idDoc)
        {
            var documents = _context.Documents.ToList();
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = _context.Categories
                .Where(c => c.Id == idCat)
                .FirstOrDefault();
            
            var document = _context.Documents
                .Where(d => d.Id == idDoc
                && category.Id == idCat)
                .Include(c => c.Category);
            //.Include(c => c.Category)
            //.Include(o => o.Department)
            //.Include(l => l.Laws)
            //.Include(f => f.Files)
            //.FirstOrDefault();
            // ViewBag.Category = category;
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.Document = document;
            //ViewBag.Files = document.Files;
            return View(documents);


        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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


        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
