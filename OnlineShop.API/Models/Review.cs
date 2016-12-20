using System;

namespace OnlineShop.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User ReviewedBy { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}