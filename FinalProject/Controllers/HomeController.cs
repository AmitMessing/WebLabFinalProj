using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext ctx;

        public HomeController()
        {
            ctx = new SiteContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            List<IMedia> mediaList = new List<IMedia>(ctx.Media.ToList());
            return View(mediaList);
        }

        public ActionResult GetMovie(Guid id = default(Guid))
        {
            return RedirectToAction("MediaDetails", "Media", new {id = id});
        }
    }
}