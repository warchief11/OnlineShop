using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public interface IOrderService
    {
        List<Item> GetMenu();
        Basket GetBasket(int userId);

        Basket AddItem(Item item);

        Basket Remove(int id);
        Order GetOrder(int id);
        Basket Post(Basket basket);
    }
}