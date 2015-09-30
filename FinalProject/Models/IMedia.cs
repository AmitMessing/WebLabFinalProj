using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        string Directors { get; set; }

        string Producers { get; set; }

        string Actors { get; set; }

        string Image { get; set; }
    }


    public enum Category
    {
        [Display(Name = "קומדיה")]
        Comedy,
        [Display(Name = "דרמה")]
        Drama,
        [Display(Name = "פעולה")]
        Action,
        [Display(Name = "רומנטיקה")]
        Romance,
        [Display(Name = "אימה")]
        Horror,
        [Display(Name = "אנימציה")]
        Animation,
        [Display(Name = "פשע")]
        Crime,
        [Display(Name = "מתח")]
        Thriller,
        [Display(Name = "פנטזיה")]
        Fantasy,
        [Display(Name = "מדע בדיוני")]
        SciFi,
    }
}