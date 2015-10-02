using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Media: IMedia
    {
        public Media()
        {

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

            if (mediaViewModel.Image.ContentLength > 0)
            {
                byte[] fileBytes = new byte[mediaViewModel.Image.InputStream.Length];
                int byteCount = mediaViewModel.Image.InputStream.Read(fileBytes, 0, (int)mediaViewModel.Image.InputStream.Length);
                Image = Convert.ToBase64String(fileBytes);
            }
        }

        public Guid Id { get; set; }

        public MediaType MediaType { get; set; }

        public string HebrewTitle { get; set; }

        public string EnglishTitle { get; set; }

        public Category Category { get; set; }

        public string Summery { get; set; }

        public double Rank { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int Length { get; set; }

        public string Directors { get; set; }

        public string Producers { get; set; }

        public string Actors { get; set; }

        public string Image { get; set; }
    }

}