using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public class Repository : IRepository
    {
        private static List<Flight> _flights = new List<Flight>();
        private static List<Gate> _gates = new List<Gate>();
        private static List<Reservation> _reservations = new List<Reservation>();

        public Repository()
        {
            SeedData();
        }

        private void SeedData()
        {
            _flights.Clear();
            _gates.Clear();
            _reservations.Clear();
            for (int i = 1; i < 20; i++)
            {
                _flights.Add(new Flight { Id = i, AirLine = "Quantas", Name = "QN" + i.ToString() });
                _flights.Add(new Flight { Id = i + 20, AirLine = "Virgin Australia", Name = "VA" + (i + 20).ToString() });
                _flights.Add(new Flight { Id = i + 40, AirLine = "Cathay Pacific", Name = "CP" + (i + 40).ToString() });

                _gates.Add(new Gate { Id = i, Name =  "Gate-" + i.ToString() });

            }
            _reservations.Add(new Reservation { Id = 1, GateId = 2, Gate = _gates.FirstOrDefault(g => g.Id == 2), Flight = _flights.FirstOrDefault(f => f.Id == 1), FlightId = 1, Arrival = DateTime.Today.AddHours(5), Departure = DateTime.Today.AddHours(6), Destination = "AuckLand" });
            _reservations.Add(new Reservation { Id = 2, GateId = 3, Gate = _gates.FirstOrDefault(g => g.Id == 3), Flight = _flights.FirstOrDefault(f => f.Id == 5), FlightId = 5, Arrival = DateTime.Today.AddHours(5), Departure = DateTime.Today.AddHours(5.5), Destination = "Canberra" });
            _reservations.Add(new Reservation { Id = 3, GateId = 3, Gate = _gates.FirstOrDefault(g => g.Id == 3), Flight = _flights.FirstOrDefault(f => f.Id == 4), FlightId = 4, Arrival = DateTime.Today.AddHours(5.5), Departure = DateTime.Today.AddHours(6), Destination = "Melbourne" });

        }
        public List<Flight> Flights
        {
            get
            {
                return _flights;
            }

            set
            {
                _flights = value;
            }
        }

        public List<Gate> Gates
        {
            get
            {
                return _gates;
            }

            set
            {
                _gates = value;
            }
        }

        public List<Reservation> Reservations
        {
            get
            {
                return _reservations;
            }

            set
            {
                _reservations = value;
            }
        }
    }

    public interface IRepository
    {
        List<Flight> Flights { get; set; }
        List<Gate> Gates { get; set; }
        List<Reservation> Reservations { get; set; }
    }
}