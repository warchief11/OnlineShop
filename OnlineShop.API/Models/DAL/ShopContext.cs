using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OnlineShop.API.Models.DAL 
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}