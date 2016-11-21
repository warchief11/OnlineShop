using ParkAssist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkAssist.Controllers.api
{
    public class ReservationsController : ApiController
    {
        private FlightManager _flightManager = null;
        
        public ReservationsController()
        {
            _flightManager = new FlightManager(new Repository());
        }

        public Reservation Get(int id)
        {
            return _flightManager.GetReservations().FirstOrDefault(g => g.Id == id);
        }

        public IList<Reservation> GetReservations(int? gateId = null)
        {
            return _flightManager.GetReservations(gateId);
        }
    }
}
