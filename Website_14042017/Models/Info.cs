using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class Info
    {
        [Key]
        public string Id { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Điện thoại")]
        public string Hotline { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Website")]
        public string Web { get; set; }
        public string InforOther { get; set; }
    }
}