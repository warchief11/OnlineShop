using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int GateId { get; set; }
        public int FlightId { get; set; }
        public Gate Gate { get; set; }
        public Flight Flight { get; set; }

        public string Destination { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public FlightStatus Status { get; set; }
    }
}