using ParkAssist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkAssist.Controllers.api
{
    public class GatesController : ApiController
    {
        private FlightManager _flightManager = null;
        
        public GatesController()
        {
            _flightManager = new FlightManager(new Repository());
        }

        public Gate Get(int id)
        {
            return _flightManager.GetGates().FirstOrDefault(g => g.Id == id);
        }
        public IList<Gate> GetGates()
        {
            return _flightManager.GetGates();
        }
    }
}
