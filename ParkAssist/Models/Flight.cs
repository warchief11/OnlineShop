using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public string AirLine { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}