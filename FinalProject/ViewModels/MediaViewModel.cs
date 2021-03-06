﻿using FinalProject.Models;
using System;
using System.CodeDom;
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
            Comments = new List<Comment>();
        }

        public MediaViewModel(Media media){
            Comments = new List<Comment>();

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
            Comments = media.Comments;

        }

        public Guid Id { get; set; }

        [DisplayName("סוג המדיה")]
        public MediaType MediaType { get; set; }

        [DisplayName("שם בעברית")]
        public string HebrewTitle { get; set; }

        [DisplayName("שם באנגלית")]
        public string EnglishTitle { get; set; }

        [DisplayName("ז'אנר")]
        public enmCategory Category { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("תקציר")]
        public string Summery { get; set; }

        /// <summary>From imdb</summary>
        [DisplayName("דירוג")]
        public double Rank { get; set; }

        [DisplayName("תאריך יציאה לעולם")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
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

        [DisplayName("תגובות")]
        public List<Comment> Comments { get; set; }

        [DisplayName("תמונה")]
        public HttpPostedFileBase Image { get; set; }
    }
}