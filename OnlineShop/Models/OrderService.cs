using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderService : IOrderService
    {
        private static List<Item> _items = null;
        private static Basket _basket;
        private static Order _order;
        #region Static Helper Methods

        public static Item DummyItem(int userId)
        {
            return new Item
            {
                Id = userId,
                Description = "Item no. " + userId.ToString(),
                Price = userId % 100,
                Discount = userId % 7,
                ImageURL = string.Format("/Content/images/ItemImage/CD{0}.png", userId % 20)
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
            _basket = _basket ?? new Basket
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
            return _basket;
        }

        public Basket AddItem(Item item)
        {
            _basket.OrderItems.Add(new OrderItem { Item = DummyItem(_basket.Id), Quantity = 1 });
            return _basket;
        }

        public Basket Remove(int id)
        {
            _basket.OrderItems.RemoveAll(o => o.Item.Id == id);
            return _basket;
        }

        public List<Item> GetMenu()
        {
            _items = _items ?? new List<Item>
            {
                DummyItem(1),
                DummyItem(2),
                DummyItem(3),
                DummyItem(4),
                DummyItem(5),
                DummyItem(6),
                DummyItem(7),
                DummyItem(8)
            };
            return _items;
        }

        public Order GetOrder(int id)
        {
            _order = _order ?? new Order();
            _order.Id = id;
            _order.OrderItems = GetBasket(id).OrderItems;
            _order.ItemCost = _order.OrderItems.Any() ? _order.OrderItems.Sum(o => o.Item.Price * o.Quantity) : 0;
            _order.Shippingcost = 14;
            _order.TotalCost = _order.ItemCost + _order.Shippingcost;
            _order.ShippedTo = "Mr Smith";
            return _order;
        }

        public Basket Post(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}