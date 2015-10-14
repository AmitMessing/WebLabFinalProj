using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinalProject.Controllers
{
    public class SearchController : Controller
    {
        private SiteContext ctx;

        //Advance Search Options.
        private const string MOVIE = "סרט";
        private const string SERIE = "סדרה";
        private const string CATEGORY = "קטגוריה";
        private const string COMMENTS = "תגובות";
        private const string DIRECTOR = "במאי";

        public SearchController()
        {
            ctx = new SiteContext();
        }

        // GET: Search
        public ActionResult Result()
        {
            return View(TempData["searchResult"]);
        }

        public ActionResult Search(string searchString)
        {
            if (searchString.StartsWith("@"))
            {
                TempData["searchResult"] = this.AdvanceSearch(searchString.Substring(1));
            }
            else
            {
                TempData["searchResult"] = this.SimpleSearch(searchString);
            }
            
            return RedirectToAction("Result");
        }

        public ActionResult AdvanceSearchInstruction()
        {
            return View();
        }

        private List<Media> SimpleSearch(string searchString)
        {
            return ctx.Media.Where(x => x.HebrewTitle.Contains(searchString) ||
                                x.EnglishTitle.Contains(searchString)).ToList();
        }

        public List<Media> AdvanceSearch(string searchString)
        {
            List<Media> searchResult = new List<Media>();
            string[] tempStrings = searchString.Split(' ');
            string searchCategory = tempStrings[0];

            switch (searchCategory)
            {
                case CATEGORY:
                {
                    string categoryName = tempStrings[1];
                    try
                    {
                        enmCategory category;
                        category = GetEnumValueFromDescription<enmCategory>(tempStrings[1]);
                        searchResult = ctx.Media.Where(x => x.Category == category).ToList();
                    }
                    catch{ }
                        
                    break;
                }
                case COMMENTS:
                {
                    string userName = tempStrings[1];
                    User user = ctx.Users.First(x => x.UserName.ToLower().Equals(userName.ToLower()));
                    IQueryable<Comment> userComments = ctx.Comments.Where(x => x.UserId == user.Id);
                    searchResult = ctx.Media.Where(x => userComments.Any(c => c.MediaId == x.Id)).ToList();
                    break;
                }
                case DIRECTOR:
                {
                    string directorName = tempStrings[1];
                    searchResult = ctx.Media.Where(x => x.Directors.Contains(directorName)).ToList();
                    break;
                }
                case MOVIE:
                case SERIE:
                {
                    MediaType mediaType = searchCategory == MOVIE ? MediaType.Movie : MediaType.Series;
                    IQueryable<Media> tempResult = null;
                    
                    // that means we have a category.
                    if (tempStrings.Count() > 1)
                    {
                        enmCategory category;
                        try
                        {
                            category = GetEnumValueFromDescription<enmCategory>(tempStrings[1]);
                            tempResult = ctx.Media.Where(x => x.MediaType == mediaType);
                            tempResult = tempResult.Where(x => x.Category == category);
                        }
                        catch{ }
                    }
                    // that means we have a year.
                    if (tempStrings.Count() > 2)
                    {
                        int year;
                        if (int.TryParse(tempStrings[2], out year))
                        {
                            tempResult = tempResult.Where(x => x.ReleaseDate.Year == year);
                        }
                    }

                    if(tempResult != null)
                        searchResult = tempResult.ToList();
                    break;
                }
                default:
                {
                    break;
                }
            }

            return searchResult;
        }

        public static T GetEnumValueFromDescription<T>(string name)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis)
            {
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Name == name)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            throw new Exception("Not found");
        }
    }
}