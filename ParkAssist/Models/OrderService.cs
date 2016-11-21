using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkAssist.Models
{
    public class OrderService : IOrderService
    {
        #region Static Helper Methods

        public static Item DummyItem(int userId)
        {
            return new Item
            {
                Id = userId,
                Description = "Item no. " + userId.ToString(),
                Price = userId % 100,
                Discount = userId % 7,
                ImageURL = string.Format("/Content/Images/AlbumArt/CD{0}.png", userId % 20)
            };
        }

        public static OrderItem DummyOrderItem(int userId)
        {
            return new OrderItem
            {
                Item = DummyItem(userId),
                Quantity = userId % 9
            };
        }
        #endregion

        public Basket GetBasket(int userId)
        {
            //TODO: replace with 3rd party API call.
            return new Basket
            {
                Id = userId,
                OrderItems = new List<OrderItem>
                {
                   DummyOrderItem(userId),
                   DummyOrderItem(userId + 1),
                   DummyOrderItem(userId + 2),
                   DummyOrderItem(userId + 3)
                }
            };
        }

        public List<Item> GetMenu()
        {
            var items = GetBasket(4).OrderItems.Select(o => o.Item).ToList();
            return items;
        }

        public Order GetOrder(int id)
        {
            var order = new Order();
            order.Id = id;
            order.OrderItems = GetBasket(id).OrderItems;
            order.ItemCost = order.OrderItems.Any() ? order.OrderItems.Sum(o => o.Item.Price * o.Quantity) : 0;
            order.Shippingcost = 14;
            order.TotalCost = order.ItemCost + order.Shippingcost;
            order.ShippedTo = "Mr Smith";
            return order;
        }
    }
}