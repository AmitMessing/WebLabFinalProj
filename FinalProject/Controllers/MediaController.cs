using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class MediaController : Controller
    {
        private SiteContext ctx;

        public MediaController()
        {
            ctx = new SiteContext();
        }

        public ActionResult AllMovies()
        {
            return View(ctx.Media.Where<Media>(x => x.mediaType == MediaType.Movie).ToList());
        }

        // GET: Media
        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedia(MediaViewModel mediaViewModel)
        {
            mediaViewModel.Id = Guid.NewGuid();
            ctx.Media.Add(new Media(mediaViewModel));
            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MediaDetails(Guid id)
        {
            var media = ctx.Media.Find(id);
            if (media != null)
            {
                return View(media);
            }
            return RedirectToAction("Index","Home");
        }
    }
}