﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Series : IMedia
    {
        public Guid Id { get; set; }

        [DisplayName("שם הסרט בעברית")]
        public string HebrewTitle { get; set; }

        [DisplayName("שם הסרט באנגלית")]
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
        [DisplayName("אורך הסרט")]
        public int Length { get; set; }

        [DisplayName("במאי")]
        public string Directors { get; set; }

        [DisplayName("מפיק")]
        public string Producers { get; set; }

        [DisplayName("שחקנים")]
        public string Actors { get; set; }

        [DisplayName("תמונה")]
        public string Image { get; set; }
    }
}