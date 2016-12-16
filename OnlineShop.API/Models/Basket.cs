using System.Collections.Generic;

namespace OnlineShop.API.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalCost { get; set; }
    }
}