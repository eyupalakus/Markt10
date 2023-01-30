using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Housefold
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public string Control_Type { get; set; }
        public string Special_Feature { get; set; }
        public string Guarantee { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
