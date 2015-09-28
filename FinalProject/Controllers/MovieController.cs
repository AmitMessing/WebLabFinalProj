using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class MovieController : Controller
    {
        private SiteContext ctx;

        public MovieController()
        {
            ctx = new SiteContext();
        }

        // GET: Movie
        public ActionResult AddMovie()
        {
            return View();
        }
    }
}