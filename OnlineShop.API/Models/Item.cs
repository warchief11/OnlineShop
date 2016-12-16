using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        [DataType(DataType.ImageUrl)]
        [StringLength(1024)]
        public string ImageURL { get; set; }
    }
}