using System.ComponentModel.DataAnnotations;

namespace Markt10.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TrademarkId { get; set; }
        public Trademark Trademark { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
