using AghaShad_Shop.Views;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions.ViewsConfiguration
{
    public static class CustomerAddressViewConfiguration
    {
        public static void CustomerAddressViewRegistration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddressView>().HasNoKey();
            modelBuilder.Entity<CustomerAddressView>().ToView("CustomerAddressView", "dbo");
        }
    }
}
