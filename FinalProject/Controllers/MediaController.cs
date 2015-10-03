using FinalProject.Models;
using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult DeleteMedia(Guid id = default (Guid))
        {
            var media = ctx.Media.Find(id);
            if (media != null)
            {
                ctx.Media.Remove(media);
            }
            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditMedia(Guid id = default(Guid))
        {
            Media media = ctx.Media.Find(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            media.ReleaseDate = media.ReleaseDate.Date;
            return View(media);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMedia(MediaViewModel mediaViewModel)
        {
            var media = ctx.Media.Find(mediaViewModel.Id);
            if (media != null)
            {
                media.Actors = mediaViewModel.Actors;
                media.Category = mediaViewModel.Category;
                media.Directors = mediaViewModel.Directors;
                media.EnglishTitle = mediaViewModel.EnglishTitle;
                media.HebrewTitle = mediaViewModel.HebrewTitle;
                media.Length = mediaViewModel.Length;
                media.MediaType = mediaViewModel.MediaType;
                media.Producers = mediaViewModel.Producers;
                media.Rank = mediaViewModel.Rank;
                media.ReleaseDate = mediaViewModel.ReleaseDate;

                if (mediaViewModel.Image != null)
                {
                    if (mediaViewModel.Image.ContentLength > 0)
                    {
                        byte[] fileBytes = new byte[mediaViewModel.Image.InputStream.Length];
                        int byteCount = mediaViewModel.Image.InputStream.Read(fileBytes, 0,
                            (int)mediaViewModel.Image.InputStream.Length);
                        media.Image = Convert.ToBase64String(fileBytes);
                    }
                }
            }

            ctx.Entry(media).State = EntityState.Modified;
            ctx.SaveChanges();
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