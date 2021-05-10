using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreeChoiceDiscipline.DAL.Models
{
    public class UserRegistration
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required]
        public string Login { get; set; } // email or username
        [Required]
        //TODO validation
        //[MinLength(8)]
        public string Password { get; set; }
    }
}
