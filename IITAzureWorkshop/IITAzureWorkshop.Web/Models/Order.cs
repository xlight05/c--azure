using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IITAzureWorkshop.Web.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}