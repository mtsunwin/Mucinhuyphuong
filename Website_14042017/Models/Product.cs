using System.ComponentModel.DataAnnotations;

namespace Website_14042017.Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Country { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public string Descrip { get; set; }
        public string Image { get; set; }
    }
}