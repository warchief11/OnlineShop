using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public class FlightManager
    {
        private IRepository _repo;
        public FlightManager(IRepository repo)
        {
            _repo = repo;
        }

        public List<Gate> GetGates()
        {
            return _repo.Gates.ToList();
        }

        public List<Reservation> GetReservations(int? gateId = null, int? flightID = null)
        {
            return _repo.Reservations.Where(r => (!gateId.HasValue || gateId.Value == r.GateId)
                                           && (!flightID.HasValue || flightID.Value == r.FlightId))
                              .ToList();
        }

        public void DeleteReservation(Reservation reservation)
        {
            _repo.Reservations.Remove(reservation);
        }

        public void UpdateReservation(Reservation reservation, bool force = false)
        {
            var overlap = GetOverlappingReservation(_repo.Reservations, reservation);
            if (overlap != null)
            {
                if (force)
                {
                    PostPoneReservation(_repo.Reservations, overlap, (reservation.Departure - overlap.Arrival).Minutes + 1);
                }
                else
                {
                    throw new ArgumentException(string.Format("Cannot reserve at Gate {0} at this time duration as there is an conflicting reseravation.", reservation.GateId));
                }
            }
            _repo.Reservations.Add(reservation);
        }

        public Reservation AddReservation(int gateId, int flightID, DateTime arrivalTime, DateTime? departure = null, string destination = "", bool force = false)
        {
            departure = departure ?? arrivalTime.AddMinutes(29);
           
            var reservation = new Reservation 
                                            {
                                                //ignoring thread saftery for simplistic scneario. In complex scenario, DB will create identity primary key.
                                                Id = _repo.Reservations.Count() + 1, 
                                                GateId = gateId,
                                                FlightId =flightID,
                                                Arrival = arrivalTime,
                                                Departure = departure.Value,
                                                Destination = destination,
                                                Status = FlightStatus.Scheduled
                                            };
            var overlap = GetOverlappingReservation(_repo.Reservations, reservation);
            if(overlap != null)
            {
                if(force)
                {
                    PostPoneReservation(_repo.Reservations, overlap, (reservation.Departure - overlap.Arrival).Minutes + 1);
                }
                else
                {
                     throw new ArgumentException(string.Format("Cannot reserve at Gate {0} at this time duration as there is an conflicting reseravation.", gateId));
                }
            }
            _repo.Reservations.Add(reservation);
            return reservation;
        }

        public void UpdateArrival(Reservation reservation, DateTime newArrival, bool force = false)
        {
            reservation.Departure += newArrival - reservation.Arrival;
            reservation.Arrival = newArrival;
            UpdateReservation(reservation, force);
        }

        private void PostPoneReservation(List<Reservation> reservations, Reservation reservation, int overLapMinutes)
        {
            reservation.Arrival = reservation.Arrival.AddMinutes(overLapMinutes);
            reservation.Departure =reservation.Departure.AddMinutes(overLapMinutes);
            var overlappingReservation = GetOverlappingReservation(reservations, reservation);
            if(overlappingReservation != null)
            {
                overLapMinutes = (reservation.Departure - overlappingReservation.Arrival).Minutes + 1;
                PostPoneReservation(reservations, overlappingReservation, overLapMinutes);
                //there can be two overlaps at max
                overlappingReservation = GetOverlappingReservation(reservations, reservation);
                if (overlappingReservation != null)
                {
                    overLapMinutes = (reservation.Departure - overlappingReservation.Arrival).Minutes + 1;
                    PostPoneReservation(reservations, overlappingReservation, overLapMinutes);
                }
            }
        }

        private Reservation GetOverlappingReservation(List<Reservation> reservations, Reservation reservation)
        {
            return reservations.FirstOrDefault(r => r.GateId == reservation.GateId
                                     && r.Id != reservation.Id
                                     && r.Arrival <= reservation.Departure
                                     && r.Departure >= reservation.Arrival);
        }
    }
}