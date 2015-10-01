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

        public ActionResult AllMovies()
        {
            return View(ctx.Movies.ToList());
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

        [HttpPost]
        public ActionResult MovieDetails(string id)
        {
            var movie = ctx.Movies.Find(Guid.Parse(id));
            if (movie != null)
            {
                return View(movie);
            }
        }
    }
}