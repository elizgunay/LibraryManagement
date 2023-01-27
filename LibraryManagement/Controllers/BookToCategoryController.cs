using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.BookToCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class BookToCategoryController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            return View(db.BookToCategories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");
            ViewData["categoryById"] = db.Categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model, int[] CategoryIds)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();


            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                foreach (int catId in CategoryIds)
                {
                    BookToCategory item = new BookToCategory();
                    item.BookId = model.BookId;
                    item.CategoryId = catId;

                    db.BookToCategories.Add(item);
                    db.SaveChanges();
                }

                ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");
                ViewData["categoryById"] = db.Categories;
                model.Book = db.Books.Find(model.BookId);
                return RedirectToAction("Index", "BookToCategory");
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            BookToCategory item = new BookToCategory();
            item.Id = id;

            db.BookToCategories.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "BookToCategory");
        }

    }
}
