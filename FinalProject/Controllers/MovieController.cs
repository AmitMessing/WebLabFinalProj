using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieViewModel movieViewModel)
        {
            movieViewModel.Id = Guid.NewGuid();
            ctx.Movies.Add(new Movie(movieViewModel));
            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}