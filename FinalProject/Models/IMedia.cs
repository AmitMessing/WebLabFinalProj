using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public interface IMedia
    {
        Guid Id { get; set; }

        string HebrewTitle { get; set; }
        string EnglishTitle { get; set; }

        [DisplayName("ז'אנר")]
        Category Category { get; set; }

        [DisplayName("תקציר")]
        string Summery { get; set; }

        /// <summary>
        /// From imdb
        /// </summary>
        [DisplayName("דירוג")]
        double Rank { get; set; }

        [DisplayName("תאריך יציאה לעולם")]
        DateTime ReleaseDate { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        int Length { get; set; }

        [DisplayName("במאי")]
        List<string> Directors { get; set; }

        [DisplayName("מפיק")]
        List<string> Producers { get; set; }

        [DisplayName("שחקנים")]
        List<string> Actors { get; set; }
    }


    public enum Category
    {
        Comedy,
        Drama,
        Action,
        Romance,
        Horror,
        Animation,
        Crime,
        Thriller,
        Fantasy,
        SciFi,
    }
}