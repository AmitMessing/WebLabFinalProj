using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {
        private SiteContext ctx;
        public UserController()
        {
             ctx = new SiteContext();
           
        }
        
        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            var userFromDb = ctx.Users.Find(user.Id);
            userFromDb.UserName = user.UserName;
            userFromDb.Email = user.Email;
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.Password = user.Password;
            userFromDb.Type = user.Type;
            userFromDb.RememberMe = user.RememberMe;

            ctx.Users.AddOrUpdate(userFromDb);
            ctx.SaveChanges();

            Session["LoggedinUserId"] = userFromDb.Id;
            Session["LoggedinUserName"] = userFromDb.FirstName + " " + userFromDb.LastName;
            Session["LoggedinUserType"] = userFromDb.Type;
            FormsAuthentication.SetAuthCookie(userFromDb.UserName, userFromDb.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult GetUser()
        {
            string id = String.Empty;
            if (Session["LoggedinUserId"] != null)
            {
                 id = Session["LoggedinUserId"].ToString();
                 var user = ctx.Users.Find(Guid.Parse(id));
                 return View(user);
            }
            return View();
        }
    }
}