using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            return View(db.Authors.ToList());

        }
        [HttpGet]
        public IActionResult Create()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");

            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateVM model)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            if (ModelState.IsValid)
            {
                Author item = new Author();
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.BookId = model.BookId;

                db.Authors.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index", "Author");
            }

            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");
            model.Book = db.Books.Find(model.BookId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");

            Author item = db.Authors.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Author");

            }
            else
            {
                EditVM model = new EditVM();
                model.Id = item.Id;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.BookId = item.BookId;

                return View(model);
            }


        }
        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (ModelState.IsValid)
            {
                Author item = new Author();
                item.Id = model.Id;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.BookId = model.BookId;

                LibraryManagementDbContext db = new LibraryManagementDbContext();
                db.Authors.Update(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Author");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            Author item = new Author();
            item.Id = id;

            db.Authors.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "Author");
        }
    }
}
