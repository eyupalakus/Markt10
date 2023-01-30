using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [Range(1,1000,ErrorMessage="Please enter a value 1 and 1000")]
        public int Count { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
    }
}
