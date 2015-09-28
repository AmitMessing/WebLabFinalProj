using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class User 
    {
        public Guid Id { get; set; }

        [DisplayName("שם פרטי")]
        public string FirstName { get; set; }

        [DisplayName("שם משפחה")]
        public string LastName { get; set; }

        [DisplayName("סיסמא")]
        public string Password { get; set; }

        [DisplayName("שם משתמש")]
        public string UserName { get; set; }

        [DisplayName("אימייל")]
        public string Email { get; set; }
        public UserType Type { get; set; }

        public User()
        {
            
        }
    }

    public enum UserType
    {
        Regular,
        Vip,
        Manager
    }
}