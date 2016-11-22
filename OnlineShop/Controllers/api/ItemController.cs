using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.Models;

namespace OnlineShop.Controllers.api
{
    [Route("api/basket/{basketId}/item")]
    public class ItemController : BaseAPIController
    {
        public ItemController(IOrderService orderService) : base(orderService)
        {

        }

        public void Post([FromUri] int basketId, [FromBody] Item item)
        {
            _orderService.AddItem(item);
        }

        public void Delete(int basketId, int id)
        {
            _orderService.Remove(id);
        }
    }
}
