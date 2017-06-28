using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class MenuLevel1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DisplayName{get;set;}
        [Required]
        public string IdMenuLevel0 { get; set; }
        public string Link { get; set; }
    }
}