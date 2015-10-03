using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class MediaCommentViewModel
    {
        public Media Media { get; set; }
        public Comment Comment { get; set; }

        public MediaCommentViewModel()
        {

        }

        public MediaCommentViewModel(Media m, Comment c)
        {
            Media = m;
            Comment = c;
        }
    }
}