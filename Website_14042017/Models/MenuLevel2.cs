using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class MenuLevel2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public int IdMenuLevel1 { get; set; }
        public string Link { get; set; }
    }
}