using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.AuthorToBooks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class AuthorToBookController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            return View(db.AuthorToBooks.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            ViewData["authorById"] = new SelectList(db.Authors.ToList(), "Id", "FirstName");
            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            if (ModelState.IsValid)
            {
                AuthorToBook item = new AuthorToBook();
                item.AuthorId = model.AuthorId;
                item.BookId = model.BookId;


                db.AuthorToBooks.Add(item);
                db.SaveChanges();

                return RedirectToAction("Index", "AuthorToBook");
            }

            ViewData["authorById"] = new SelectList(db.Authors.ToList(), "Id", "FirstName");
            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");
            model.Book = db.Books.Find(model.BookId);
            return View(model);

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            ViewData["bookById"] = new SelectList(db.Books.ToList(), "Id", "Title");
            ViewData["authorById"] = new SelectList(db.Authors.ToList(), "Id", "FirstName");


            AuthorToBook item = db.AuthorToBooks.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "AuthorToBook");

            }
            else
            {
                AuthorToBook model = new AuthorToBook();
                model.Id = item.Id;
                model.AuthorId = item.AuthorId;
                model.BookId = item.BookId;

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (ModelState.IsValid)
            {
                AuthorToBook item = new AuthorToBook();
                item.Id = model.Id;
                item.AuthorId = model.AuthorId;
                item.BookId = model.BookId;


                LibraryManagementDbContext db = new LibraryManagementDbContext();
                db.AuthorToBooks.Update(item);
                db.SaveChanges();

                return RedirectToAction("Index", "AuthorToBook");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            AuthorToBook item = new AuthorToBook();
            item.Id = id;

            db.AuthorToBooks.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "AuthorToBook");
        }

    }
}
