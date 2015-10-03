using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public ActionResult AllMovie()
        {
            return View(ctx.Media.Where(x => x.MediaType == MediaType.Movie).ToList());
        }

        // GET: Media
        public ActionResult AddMedia()
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

        
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            var media = ctx.Media.Find(comment.MediaId);
            var connectedUser = ctx.Users.Find(Session["LoggedinUserId"]);

            comment.UserId = connectedUser.Id;
            comment.Date = DateTime.Now;
            comment.Id = Guid.NewGuid();

            media.Comments.Add(comment);
            
            ctx.Comments.Add(comment);
            ctx.Media.Attach(media);
            var entry = ctx.Entry(media);
            entry.Collection(e => e.Comments).CurrentValue = media.Comments;
            ctx.SaveChanges();

            return RedirectToAction("MediaDetails","Media", new { id = media.Id });
        }

        public ActionResult MediaDetails(Guid id)
        {
            var comment = new Comment();
            var media = ctx.Media.Find(id);
            ctx.Entry(media).Collection(x => x.Comments).Load();
            if (media != null)
            {
                comment.MediaId = media.Id;
                return View(new MediaCommentViewModel(media, comment));
            }
            return RedirectToAction("Index","Home");
        }
    }
}