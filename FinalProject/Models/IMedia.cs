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
        [DisplayName("סוג")]
        MediaType MediaType { get; set; }

        [DisplayName("כותרת בעברית")]
        string HebrewTitle { get; set; }

        [DisplayName("כותרת באנגלית")]
        string EnglishTitle { get; set; }

        [DisplayName("ז'אנר")]
        Category Category { get; set; }

        [DisplayName("תקציר")]
        string Summery { get; set; }

        [DisplayName("דירוג")]
        double Rank { get; set; }

        [DisplayName("תאריך יציאה לעולם")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        DateTime ReleaseDate { get; set; }

        [DisplayName("אורך")]
         int Length { get; set; }

        [DisplayName("במאי")]
        string Directors { get; set; }

        [DisplayName("מפיק")]
        string Producers { get; set; }

        [DisplayName("שחקנים")]
        string Actors { get; set; }

        string Image { get; set; }

        List<Comment> Comments { get; set; }
    }

    public enum MediaType
    {
        [Display(Name = "בחר סוג מדיה")]
        None,
        [Display(Name = "סרט")]
        Movie,
        [Display(Name = "סדרה")]
        Series
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