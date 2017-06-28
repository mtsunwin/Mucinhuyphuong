using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class ProductType
    {
        [Key]
        public string Name { get; set; }
        public string Descrip { get; set; }
    }
}