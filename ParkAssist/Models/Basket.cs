using System.Collections.Generic;

namespace ParkAssist.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}