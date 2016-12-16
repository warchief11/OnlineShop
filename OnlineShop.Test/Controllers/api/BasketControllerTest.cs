using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.API.Models;
using NUnit.Framework;
using System.Web.Http;
using System.Net.Http;
using OnlineShop.API.Controllers;

namespace OnlineShop.Controllers.api
{
    [TestFixture]
    public class BasketControllerTest
    {
        private IOrderService _orderService;
        [SetUp]
        public void Setup()
        {
            //no need to mock this service, as this is a mock service itself of 3rd party api
            _orderService = new OrderService();
        }
        [Test]
        public void GetBasket_Should_ReturnBasket()
        {
            var controller = new BasketController(_orderService);

            controller.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost/api/basket")
            };
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(1);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, 1);
            Assert.IsNotNull(response.OrderItems);
        }

        //[Test]
        //public void PostBasket_Should_SaveBasket()
        //{
        //    var controller = new BasketController(_orderService);

        //    controller.Request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("http://localhost/api/basket")
        //    };
        //    controller.Configuration = new HttpConfiguration();

        //    var basket = new Basket { Id = 1, OrderItems = new List<OrderItem> { OrderService.DummyOrderItem(1) } };

        //    var response = controller.Post(basket);

        //    Assert.IsNotNull(response);
        //    Assert.AreEqual(response.Id, basket.Id);
        //}
    }
}
