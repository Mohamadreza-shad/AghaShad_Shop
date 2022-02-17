using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class ShippingModelBuilderExtension
    {
        public static void ShippingOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<Shipping>().ToTable("Shippings");

            builder.Entity<Shipping>().HasKey(pk => pk.Id);

            builder.Entity<Shipping>().Property(pr => pr.Name)
                                      .HasColumnName("Name")
                                      .IsRequired();

            builder.Entity<Shipping>().HasMany(ord => ord.OrderHeaders)
                                      .WithOne(ship => ship.Shipping)
                                      .HasForeignKey(fk => fk.ShippingId)
                                      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
