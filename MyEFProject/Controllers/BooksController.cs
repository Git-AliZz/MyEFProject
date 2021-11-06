using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEFProject_DataAccess.Data;
using MyEFProject_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEFProject.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _db;
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.ToList();

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM bookVM = new BookVM();
            bookVM.PublisherList = _db.Publishers.Select(P => new SelectListItem()
            {
                Text = P.Name,
                Value = P.Publisher_Id.ToString()
            });

            if (id == null)
            {
                return View(bookVM);
            }

            bookVM.Book = _db.Books.Find(id);
            if (bookVM.Book == null)
            {
                return NotFound();
            }

            return View(bookVM);
        }
    }
}
