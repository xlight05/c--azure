using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IITAzureWorkshop.Web.Models
{
    public class OrderDto
    {
        [Required]
        public string Email { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}