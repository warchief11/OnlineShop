using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.API.Models
{
    public class OrderItem
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }    
        public decimal Cost { get; set; }   
    }
}