using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Movie : IMedia
    {
        public Movie()
        {

        }

        public Movie(MovieViewModel movieViewModel)
        {
            Id = movieViewModel.Id;
            HebrewTitle = movieViewModel.HebrewTitle;
            EnglishTitle = movieViewModel.EnglishTitle;
            Category = movieViewModel.Category;
            Summery = movieViewModel.Summery;
            Rank = movieViewModel.Rank;
            ReleaseDate = movieViewModel.ReleaseDate;
            Length = movieViewModel.Length;
            Directors = movieViewModel.Directors;
            Producers = movieViewModel.Producers;
            Actors = movieViewModel.Actors;

            if (movieViewModel.Image.ContentLength > 0)
            {
                byte[] fileBytes = new byte[movieViewModel.Image.InputStream.Length];
                int byteCount = movieViewModel.Image.InputStream.Read(fileBytes, 0, (int)movieViewModel.Image.InputStream.Length);
                Image = Convert.ToBase64String(fileBytes);
            }
        }

        public Guid Id { get; set; }

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