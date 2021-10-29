using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyEFProject_Model.Models;
using MyEFProject_DataAccess.Data;

namespace MyEFProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> list = _context.Categories.ToList();

            return View(list);
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();

            if (id == null)
            {
                return View(category);
            }

            category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category==null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                _context.Categories.Update(category);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.First(c => c.Id == id);
            _context.Categories.Remove(category);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
