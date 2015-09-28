using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        [DisplayName("כותרת")]
        public string Title { get; set; }

        [DisplayName("תוכן")]
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
    }
}