using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class LoginController : Controller
    {
        private SiteContext _ctx;

        public LoginController()
        {
            _ctx = new SiteContext();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return RedirectToAction("Register", "Register");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var usrFromDb = IsValid(user);
                if (usrFromDb != null)
                {
                    Session["LoggedinUserId"] = usrFromDb.Id;
                    Session["LoggedinUserName"] = usrFromDb.FirstName + " " + usrFromDb.LastName;
                    Session["LoggedinUserType"] = usrFromDb.Type;
                    FormsAuthentication.SetAuthCookie(usrFromDb.UserName, usrFromDb.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return RedirectToAction("Index","Login");
        }
        public ActionResult Logout()
        {
            Session["LoggedinUserId"] = null;
            Session["LoggedinUserName"] = null;
            Session["LoggedinUserType"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private User IsValid(User user)
        {
            return _ctx.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
        }
    }

}