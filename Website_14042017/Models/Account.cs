using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Web { get; set; }
        public string Blog { get; set; }
        public string Descrip { get; set;}
    }
}