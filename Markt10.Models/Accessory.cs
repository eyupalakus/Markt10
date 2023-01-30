using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Accessory
    {
        public int Id { get; set; }
        [Required]
        public string OS { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string Bluetooth { get; set; }
        [Required]
        public string Processor { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
