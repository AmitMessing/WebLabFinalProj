using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Movie : IMedia
    {
        public Guid Id { get; set; }
        public string HebrewTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Summery { get; set; }
        public double Rank { get; set; }
        public DateTime ReleaseDate { get; set; }

        [DisplayName("אורך הסרט")]
        public int Length { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Producers { get; set; }
        public List<string> Actors { get; set; }
    }

}