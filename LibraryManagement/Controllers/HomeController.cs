using LibraryManagement.Entities;
using LibraryManagement.ExtensionMethods;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                Librarian item = new Librarian();
                item.Username = model.Username;
                item.Password = model.Password;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;


                LibraryManagementDbContext db = new LibraryManagementDbContext();
                db.Librarians.Add(item);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!this.ModelState.IsValid)
                return View(model);

            LibraryManagementDbContext db = new LibraryManagementDbContext();
            Librarian loggedUser = db.Librarians.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                .FirstOrDefault();

            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }
            HttpContext.Session.SetObject("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }

        [AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }

    }
}
