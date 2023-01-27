using LibraryManagement.Entities;
using LibraryManagement.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LibraryManagement.Controllers
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<Librarian>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Login");
        }
    }
}