using AghaShad_Shop.Extensions;
using AghaShad_Shop.Extensions.ViewsConfiguration;
using AghaShad_Shop.Models;
using AghaShad_Shop.Views;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.DataContext
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> Context) : base(Context) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<CustomerAddressView> CustomerAddressView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entities
            modelBuilder.ShippingOnModelBuilderExtension();
            modelBuilder.OrderDetailOnModelBuilderExtension();
            modelBuilder.OrderHeaderOnModelBuilderExtension();
            modelBuilder.CustomerOnModelBuilderExtension();
            modelBuilder.AddressOnModelBuilderExtension();
            modelBuilder.ProductOnModelBuilderExtension();

            //Views
            modelBuilder.CustomerAddressViewRegistration();
        }
    }   
}
