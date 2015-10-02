using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class MediaViewModel
    {
        public MediaViewModel()
        {

        }

        public MediaViewModel(Media media){
            Id = media.Id;
            MediaType = MediaType.None;
            HebrewTitle = media.HebrewTitle;
            EnglishTitle = media.EnglishTitle;
            Category = media.Category;
            Summery = media.Summery;
            Rank = media.Rank;
            ReleaseDate = media.ReleaseDate;
            Length = media.Length;
            Directors = media.Directors;
            Producers = media.Producers;
            Actors = media.Actors;
        }

        public Guid Id { get; set; }

        [DisplayName("סוג המדיה")]
        public MediaType MediaType { get; set; }

        [DisplayName("שם בעברית")]
        public string HebrewTitle { get; set; }

        [DisplayName("שם באנגלית")]
        public string EnglishTitle { get; set; }

        [DisplayName("ז'אנר")]
        public Category Category { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("תקציר")]
        public string Summery { get; set; }

        /// <summary>From imdb</summary>
        [DisplayName("דירוג")]
        public double Rank { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("תאריך יציאה לעולם")]
        public DateTime ReleaseDate { get; set; }

        /// <summary> In minutes </summary>
        [DisplayName("אורך")]
        public int Length { get; set; }

        [DisplayName("במאי")]
        public string Directors { get; set; }

        [DisplayName("מפיק")]
        public string Producers { get; set; }

        [DisplayName("שחקנים")]
        public string Actors { get; set; }

        [DisplayName("תמונה")]
        public HttpPostedFileBase Image { get; set; }
    }
}