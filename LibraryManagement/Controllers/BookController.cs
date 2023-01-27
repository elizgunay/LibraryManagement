using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            return View(db.Books.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            if (ModelState.IsValid)
            {
                Book item = new Book();
                item.Title = model.Title;
                item.SerialNumber = model.SerialNumber;
                item.Publisher = model.Publisher;

                db.Books.Add(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Book");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
         

            Book item = db.Books.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                EditVM model = new EditVM();
                model.Id = item.Id;
                model.Title = item.Title;
                model.SerialNumber = item.SerialNumber;
                model.Publisher = item.Publisher;

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {

            if (ModelState.IsValid)
            {
                Book item = new Book();
                item.Id = model.Id;
                item.Title = model.Title;
                item.SerialNumber = model.SerialNumber;
                item.Publisher = model.Publisher;

                LibraryManagementDbContext db = new LibraryManagementDbContext();
                db.Books.Update(item);
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            Book item = new Book();
            item.Id = id;

            db.Books.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "Book");




        }
    }
}
