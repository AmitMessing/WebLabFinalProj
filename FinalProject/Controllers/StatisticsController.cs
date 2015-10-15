using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using WebGrease.Css.Extensions;
using System.Drawing;

namespace FinalProject.Controllers
{
    public class StatisticsController : Controller
    {
        private SiteContext ctx;
        Random randonGen = new Random();

        public class DonutData
        {
            public string categoryName;
            public string color;
            public int count;
        }
        public StatisticsController()
        {
            ctx = new SiteContext();
        }

        // GET: Statistics
        public ActionResult Index()
        {
            IDictionary<enmCategory, DonutData> donutData = new Dictionary<enmCategory, DonutData>();
            ctx.Comments.ForEach(c =>
            {
                Media media = ctx.Media.Where(m => m.Id == c.MediaId).ToList()[0];
                
                if (donutData.ContainsKey(media.Category))
                {
                    donutData[media.Category].count++;
                }
                else
                {
                    string categoryName = Common.Common.GetDisplayValue(media.Category);
                    donutData.Add(media.Category, new DonutData() { categoryName = categoryName, color = randomColor(), count = 1 });
                }
            });

            return View(donutData.Values.ToArray());
        }

        private string randomColor()
        {
            return ColorTranslator.ToHtml(Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255)));
        }
    }
}