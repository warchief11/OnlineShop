using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public interface IOrderService
    {
        List<Item> GetMenu();
        Basket GetBasket(int userId);
        Order GetOrder(int id);
    }
}