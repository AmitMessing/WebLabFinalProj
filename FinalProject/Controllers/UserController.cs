using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}