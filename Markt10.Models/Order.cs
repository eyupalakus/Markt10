using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ShippingDate { get; set; }
        [DefaultValue("false")]
        public bool Status { get; set; }
        public int Count { get; set; }
    }
}
