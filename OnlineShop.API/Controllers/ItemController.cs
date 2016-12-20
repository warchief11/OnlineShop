using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShop.API.Models;

namespace OnlineShop.API.Controllers
{
    [Route("api/basket/{basketId}/item/{id?}")]
    public class ItemController : BaseAPIController
    {
        public ItemController(IOrderService orderService) : base(orderService)
        {

        }

        public void Post([FromUri] int basketId, [FromBody] Item item)
        {
            _orderService.AddItem(item);
        }

        [HttpDelete]
        public void Delete(int basketId, int id)
        {
            _orderService.Remove(id);
        }
    }
}
