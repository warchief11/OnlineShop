using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.API.Models;

namespace OnlineShop.API.Controllers
{
    public class MenuController : BaseAPIController
    {
        public MenuController(IOrderService orderService) : base(orderService)
        {

        }

        // GET: api/Menu
        public IEnumerable<Item> Get()
        {
            return _orderService.GetMenu();
        }
        
    }
}
