using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class User 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
    }

    public enum UserType
    {
        Regular,
        Vip,
        Manager
    }
}