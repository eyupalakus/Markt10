using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Camera { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
