﻿using FinalProject.Models;
using System;
using System.Collections.Generic;
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
            List<IMedia> mediaList = new List<IMedia>();
            mediaList.AddRange(ctx.Movies.ToList());
            mediaList.AddRange(ctx.Series.ToList());

            return View(mediaList);
        }
    }
}