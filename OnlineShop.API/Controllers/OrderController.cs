using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.API.Models;

namespace OnlineShop.API.Controllers
{
    [Authorize]
    public class OrderController : BaseAPIController
    {
        public OrderController(IOrderService orderService) : base(orderService)
        {

        }

        // GET: api/Menu
        public Order Get(int id)
        {
            return _orderService.GetOrder(id);
        }
        
        public Order Post()
        {
           return _orderService.CreateOrder();
        }
    }
}
