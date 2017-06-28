using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_14042017.Areas.Admin.Models
{
    public class ModelNews
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Descrip { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}