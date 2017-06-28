using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_14042017.ModelViews
{
    public class NewsView
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrip { get; set; }
        public string Content { get; set; }
        public string DatePost { get; set; }
        public string Author { get; set; }
        public string Status { get; set; }//writing, completed.
    }
}