using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkAssist.Models;

namespace ParkAssist.Controllers.api
{
    public class CartController : BaseAPIController
    {
        public CartController(IOrderService orderService) : base(orderService)
        {

        }

        // GET: api/Menu
        public Basket Get(int userId = 1)
        {
            return _orderService.GetBasket(userId);
        }
        
    }
}
