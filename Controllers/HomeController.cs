﻿using KnowledgeBase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KnowledgeBase.Data;


namespace KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    // var documents = _context.Documents.ToList();
        //    var documents = _context.Documents
        //       .OrderByDescending(d => d.DateCreate)
        //       .ThenBy(d => d.Id)
        //       .ToList();
        //    ViewBag.Category = _context.Categories.ToList();
        //    return View(documents);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}