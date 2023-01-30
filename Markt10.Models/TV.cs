using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class TV
    {
        public int Id { get; set; }
        public string Screen_Type { get; set; }
        public string Screen_Size { get; set; }
        public string Image_Quality { get; set; }
        public string OS { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
