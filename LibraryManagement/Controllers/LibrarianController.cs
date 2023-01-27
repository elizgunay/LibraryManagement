using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.Librarians;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class LibrarianController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            return View(db.Librarians.ToList());

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
                Librarian item = new Librarian();
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Username = model.Username;
                item.Password = model.Password;

                db.Librarians.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index", "Librarian");

            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            //Librarian item = db.Librarians.Where(u => u.Id == id)
            //                                .FirstOrDefault();

            Librarian item = db.Librarians.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Librarian");
            }
            else
            {
                EditVM model = new EditVM();
                model.Id = item.Id;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.Username = item.Username;
                model.Password = item.Password;

                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Edit(Librarian model)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            if (ModelState.IsValid)
            {
                Librarian item = new Librarian();
                item.Id = model.Id;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Username = model.Username;
                item.Password = model.Password;

                db.Librarians.Update(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Librarian");
            }
                return View(model);

           
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            Librarian item = new Librarian();
            item.Id = id;

            db.Librarians.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "Librarian");
        }
    }
}
