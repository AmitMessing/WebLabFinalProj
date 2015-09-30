using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {

        }

        public MovieViewModel(Movie movie){
            Id = movie.Id;
            HebrewTitle = movie.HebrewTitle;
            EnglishTitle = movie.EnglishTitle;
            Category = movie.Category;
            Summery = movie.Summery;
            Rank = movie.Rank;
            ReleaseDate = movie.ReleaseDate;
            Length = movie.Length;
            Directors = movie.Directors;
            Producers = movie.Producers;
            Actors = movie.Actors;
        }

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
        public HttpPostedFileBase Image { get; set; }
    }
}