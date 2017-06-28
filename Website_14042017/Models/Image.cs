using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class Image
    {
        [Key]
        public string Name { get; set; }
        public string Href { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }
}