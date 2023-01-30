using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Computer
    {
        public int Id { get; set; }
        public string Processor { get; set; }
        public string Display_Card { get; set; }
        public string Hard_Disk { get; set; }
        public string OS { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
