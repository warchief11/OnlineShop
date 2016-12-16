using OnlineShop.API.Models;
using System.Web.Http;

namespace OnlineShop.API.Controllers
{
    public abstract class BaseAPIController : ApiController
    {
        protected IOrderService _orderService;
        protected BaseAPIController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    }
}
