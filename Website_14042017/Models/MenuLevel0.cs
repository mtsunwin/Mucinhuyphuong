using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_14042017.Models
{
    public class MenuLevel0
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Prioritize { get; set; }
        public string Link { get; set; }
    }
}