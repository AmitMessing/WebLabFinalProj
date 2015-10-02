using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Media: IMedia
    {
        public Media()
        {
            Comments = new List<Comment>();
        }

        public Media(MediaViewModel mediaViewModel)
        {
            Id = mediaViewModel.Id;
            MediaType = mediaViewModel.MediaType;
            HebrewTitle = mediaViewModel.HebrewTitle;
            EnglishTitle = mediaViewModel.EnglishTitle;
            Category = mediaViewModel.Category;
            Summery = mediaViewModel.Summery;
            Rank = mediaViewModel.Rank;
            ReleaseDate = mediaViewModel.ReleaseDate;
            Length = mediaViewModel.Length;
            Directors = mediaViewModel.Directors;
            Producers = mediaViewModel.Producers;
            Actors = mediaViewModel.Actors;
            Comments = mediaViewModel.Comments;

            if (mediaViewModel.Image != null)
            {
                if (mediaViewModel.Image.ContentLength > 0)
                {
                    byte[] fileBytes = new byte[mediaViewModel.Image.InputStream.Length];
                    int byteCount = mediaViewModel.Image.InputStream.Read(fileBytes, 0,
                        (int) mediaViewModel.Image.InputStream.Length);
                    Image = Convert.ToBase64String(fileBytes);
                }
            }
        }

        public Guid Id { get; set; }

        [DisplayName("סוג")]
        public MediaType MediaType { get; set; }

        [DisplayName("כותרת בעברית")]
        public string HebrewTitle { get; set; }

        [DisplayName("כותרת באנגלית")]
        public string EnglishTitle { get; set; }

        [DisplayName("ז'אנר")]
        public Category Category { get; set; }

        [DisplayName("תקציר")]
        public string Summery { get; set; }

        [DisplayName("דירוג")]
        public double Rank { get; set; }

        [DisplayName("תאריך יציאה לעולם")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("אורך")]
        public int Length { get; set; }

        [DisplayName("במאי")]
        public string Directors { get; set; }

        [DisplayName("מפיק")]
        public string Producers { get; set; }

        [DisplayName("שחקנים")]
        public string Actors { get; set; }

        [DisplayName("תמונה")]
        public string Image { get; set; }

        [DisplayName("תגובות")]
        public List<Comment> Comments { get; set; }
    }

}