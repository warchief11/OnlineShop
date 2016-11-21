using NUnit.Framework;
using ParkAssist.Models;
using System;
using System.Linq;
namespace ParkAssist.Test
{
    [TestFixture]
    public class FlightManagerTest
    {
        private IRepository _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new Repository();
        }

        [Test]
        public void GetReservationsByGateID_Should_ReturnReservations()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            //act
            var reservations = flightManager.GetReservations(2);

            //assert
            Assert.IsTrue(reservations.Count > 0);
            Assert.IsTrue(reservations.All(x => x.GateId == 2));
        }


        [Test]
        public void AddReservation_NonConflict_Should_Sucess()
        {
            //arrange
            var flightManager = new FlightManager(_repo);

            //act
            var reservation = flightManager.AddReservation(2, 1, DateTime.Today.AddHours(3), destination: "Melbourne");

            //assert
            Assert.IsNotNull(reservation);
            Assert.IsTrue(_repo.Reservations.Any(item => item.Id == reservation.Id));
        }

        [Test]
        public void AddReservation_DefaultDeparture_Should_29MinsAfterArrival()
        {
            //arrange
            var flightManager = new FlightManager(_repo);

            //act
            var reservation = flightManager.AddReservation(2, 1, DateTime.Today.AddHours(3), destination: "Melbourne");

            //assert
            Assert.AreEqual((reservation.Departure - reservation.Arrival).Minutes, 29);
        }

        [Test]
        public void AddReservation_Conflict_Should_Fail()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation1 = flightManager.AddReservation(2, 1, DateTime.Today.AddHours(3), destination: "Melbourne");

            //act
            Assert.Throws<ArgumentException>(() => flightManager.AddReservation(2, 4, DateTime.Today.AddHours(3), destination: "Melbourne"));
        }

        [Test]
        public void AddReservation_Force_ShouldPush()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation1 = flightManager.AddReservation(2, 101, DateTime.Today.AddHours(3), departure: DateTime.Today.AddHours(3).AddMinutes(59), destination: "Melbourne");
            var reservation2 = flightManager.AddReservation(2, 102, DateTime.Today.AddHours(4), destination: "Melbourne");
            var reservation3 = flightManager.AddReservation(2, 103, DateTime.Today.AddHours(7.5), destination: "Melbourne");

            //act
            var reservation4 = flightManager.AddReservation(2, 104, DateTime.Today.AddHours(3), departure: DateTime.Today.AddHours(3).AddMinutes(59), destination: "Melbourne", force: true);

            //assert
            Assert.AreEqual(reservation4.Arrival, DateTime.Today.AddHours(3));
            //verify pushed by 1/2 hour.
            Assert.AreEqual(reservation1.Arrival, DateTime.Today.AddHours(4));
            Assert.AreEqual(reservation1.Departure, DateTime.Today.AddHours(4).AddMinutes(59));
            Assert.AreEqual(reservation2.Arrival, DateTime.Today.AddHours(5));

            //no change for flight 3
            Assert.AreEqual(reservation3.Arrival, DateTime.Today.AddHours(7.5));
        }

        [Test]
        public void CancelReservation_Should_Cancel()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation = flightManager.AddReservation(2, 101, DateTime.Today.AddHours(7.5), destination: "Melbourne");

            //act
            flightManager.DeleteReservation(reservation);

            //assert
            Assert.IsFalse(_repo.Reservations.Any(x => x.Id == reservation.Id));
        }

        [Test]
        public void UpdateReservation_Should_ChangeGate()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation = flightManager.AddReservation(2, 101, DateTime.Today.AddHours(7.5), destination: "Melbourne");

            //act
             reservation.GateId = 3;
            flightManager.UpdateReservation(reservation);

            //assert
            Assert.IsTrue(flightManager.GetReservations(3).Any(x => x.Id == reservation.Id));
            Assert.IsFalse(flightManager.GetReservations(2).Any(x => x.Id == reservation.Id));
        }

        [Test]
        public void UpdateArrival_Should_ChangeArrivalAndDeparture()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation = flightManager.AddReservation(2, 101, DateTime.Today.AddHours(7.5), destination: "Melbourne");

            //act
            flightManager.UpdateArrival(reservation, DateTime.Today.AddHours(8));

            //assert
            Assert.AreEqual(reservation.Arrival, DateTime.Today.AddHours(8));
            Assert.AreEqual(reservation.Departure, DateTime.Today.AddHours(8).AddMinutes(29));
        }

        [Test]
        public void UpdateArrival_WithConflict_Should_ChangeArrivalAndDepartureAndChangeTime()
        {
            //arrange
            var flightManager = new FlightManager(_repo);
            var reservation1 = flightManager.AddReservation(2, 101, DateTime.Today.AddHours(3), departure: DateTime.Today.AddHours(3).AddMinutes(59), destination: "Melbourne");
            var reservation2 = flightManager.AddReservation(2, 102, DateTime.Today.AddHours(4), destination: "Melbourne");
            var reservation3 = flightManager.AddReservation(2, 103, DateTime.Today.AddHours(7.5), destination: "Melbourne");

            //act
            flightManager.UpdateArrival(reservation1, DateTime.Today.AddHours(4), true);

            //assert
            Assert.AreEqual(reservation1.Arrival, DateTime.Today.AddHours(4));
            Assert.AreEqual(reservation1.Departure, DateTime.Today.AddHours(4).AddMinutes(59));
            Assert.AreEqual(reservation2.Arrival, DateTime.Today.AddHours(5));
            Assert.AreEqual(reservation2.Departure, DateTime.Today.AddHours(5).AddMinutes(29));
            Assert.AreEqual(reservation3.Arrival, DateTime.Today.AddHours(7.5));
            Assert.AreEqual(reservation3.Departure, DateTime.Today.AddHours(7).AddMinutes(59));
        }
    }
}
