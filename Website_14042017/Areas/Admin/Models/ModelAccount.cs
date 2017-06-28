using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_14042017.Areas.Admin.Models
{
    public class ModelAccount
    {
        [EmailAddress]
        [Required(ErrorMessage ="The email is required.")]
        public string Email { get; set;}
        [Required(ErrorMessage ="The password is required.")]
        public string Password { get; set; }
    }
}