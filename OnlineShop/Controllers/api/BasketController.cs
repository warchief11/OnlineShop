using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.Models;

namespace OnlineShop.Controllers.api
{
    public class BasketController : BaseAPIController
    {
        public BasketController(IOrderService orderService) : base(orderService)
        {

        }

        // GET: api/Menu
        public Basket Get(int userId = 1)
        {
            return _orderService.GetBasket(userId);
        }
        
        public Basket Post(Basket basket)
        {
            return _orderService.Post(basket);
        }
    }
}
