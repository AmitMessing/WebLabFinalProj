using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class RegisterController : Controller
    {
        private SiteContext ctx;

        public RegisterController()
        {
            ctx = new SiteContext();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }


        public ActionResult ReturnToLoginView()
        {
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            var duplicateUsers = ctx.Users.Select(x => x.UserName == user.UserName).ToList();
            if (duplicateUsers.Any())
            {
                return Content("שם משתמש כבר קיים");
            }
            user.Id = Guid.NewGuid();
            ctx.Users.Add(user);
            ctx.SaveChanges();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Login");

        }
    }
}