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

        Category Category { get; set; }

        string Summery { get; set; }

        /// <summary>From imdb</summary>
        double Rank { get; set; }     

        DateTime ReleaseDate { get; set; }

        /// <summary> In minutes </summary>
        int Length { get; set; }

        List<string> Directors { get; set; }

        List<string> Producers { get; set; }

        List<string> Actors { get; set; }

        string Image { get; set; }
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