using System.Web.Http;
using OnlineShop.API.Models;

namespace OnlineShop.API.Controllers
{
    [Authorize]
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
