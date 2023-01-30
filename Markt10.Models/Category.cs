using System.ComponentModel.DataAnnotations;

namespace Markt10.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
