using NUnit.Framework;
using OnlineShop.Models;
using System;
using System.Linq;
namespace OnlineShop.Test
{
    [TestFixture]
    public class FlightManagerTest
    {
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _orderService = new OrderService();
        }

        [Test]
        public void GetMenu_Should_ReturnMenu()
        {
        }
        
    }
}
