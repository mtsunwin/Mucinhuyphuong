using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrip { get; set; }
        public string Content { get; set; }
        public DateTime DatePost { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }//writing, completed.
    }
}