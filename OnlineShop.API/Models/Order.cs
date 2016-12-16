using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        [DataType(DataType.Currency)]
        public decimal ItemCost { get; set; }
        [DataType(DataType.Currency)]
        public decimal Shippingcost { get; set; }
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }
        public User ShippedTo { get; set; }
        public Address ShippingAddress { get; set; }
    }
}