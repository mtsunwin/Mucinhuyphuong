using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class WebsiteInfor
    {
        [Key]
        [DisplayName("Tên công ty - trụ sở")]
        public string CompanyName { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Điện thoại")]
        public string Hotline { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Website")]
        public string LinkWeb { get; set; }
        public string DislayNameWeb { get; set; }
        [DisplayName("Thông tin khác")]
        public string InforOther { get; set; }
    }
}