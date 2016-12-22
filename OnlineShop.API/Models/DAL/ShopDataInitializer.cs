using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShop.API.Models.DAL
{
    public class ShopDataInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            SeedItems(context, 20);
            //SeedOrder(context, 20);
        }

        private void SeedItems(ShopContext context, int count = 100)
        {
            var items = new List<Item>();
            for (int i = 0; i < count; i++)
            {
                context.Items.Add(DummyItem(i));
            }
            context.SaveChanges();
        }

        public Item DummyItem(int seedId)
        {
            return new Item
            {
                Description = "Item no. " + seedId.ToString(),
                Price = seedId % 100,
                Discount = seedId % 7,
                ImageURL = string.Format("/Content/images/ItemImage/CD{0}.png", seedId % 20),
                Reviews = new List<Review> {  DummyReview (seedId), DummyReview(seedId + 1) }
            };
        }

        private Review DummyReview(int seedId)
        {
            return new Review
            {
                Comments = "This item is awesome!!",
                Rating = seedId %5,
                Date = DateTime.Today.AddDays(seedId * -1)
            };
        }

        public OrderItem DummyOrderItem(int userId)
        {
            return new OrderItem
            {
                Item = DummyItem(userId),
                Quantity = userId % 9
            };
        }
    }
}