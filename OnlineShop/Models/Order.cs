using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public decimal ItemCost { get; set; }
        public decimal Shippingcost { get; set; }
        public decimal TotalCost { get; set; }
        public string ShippedTo { get; set; }
    }
}