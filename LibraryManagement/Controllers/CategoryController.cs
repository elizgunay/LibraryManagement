using LibraryManagement.Entities;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [AuthenticationFilter]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (ModelState.IsValid)
            {
                Category item = new Category();
                item.CategoryName = model.CategoryName;

                LibraryManagementDbContext db = new LibraryManagementDbContext();

                db.Categories.Add(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();

            Category item = db.Categories.Find(id);

            if (item == null)
            {
                return RedirectToAction("Index", "Category");

            }
            else
            {
                EditVM model = new EditVM();
                model.Id = item.Id;
                model.CategoryName = item.CategoryName;

                return View(model);

            }

        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (ModelState.IsValid)
            {
                Category item = new Category();
                item.Id = model.Id;
                item.CategoryName = model.CategoryName;

                LibraryManagementDbContext db = new LibraryManagementDbContext();
                db.Categories.Update(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LibraryManagementDbContext db = new LibraryManagementDbContext();
            Category item = new Category();
            item.Id = id;

            db.Categories.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index", "Category");
        }
    }
}
