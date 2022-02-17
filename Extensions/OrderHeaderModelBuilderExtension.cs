using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class OrderHeaderModelBuilderExtension
    {
        public static void OrderHeaderOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<OrderHeader>().ToTable("OrderHeaders");
            builder.Entity<OrderHeader>().HasKey(pk => pk.Id);

            builder.Entity<OrderHeader>().Property(pr => pr.Id)
                                         .HasColumnName("Id")
                                         .HasColumnType("int");

            builder.Entity<OrderHeader>().Property(pr => pr.OrderDate)
                                         .HasColumnName("OrderHeader")
                                         .IsRequired();

            builder.Entity<OrderHeader>().HasOne(ship => ship.Shipping)
                                         .WithMany(orderheader => orderheader.OrderHeaders)
                                         .HasForeignKey(fk => fk.ShippingId)
                                         .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderHeader>().HasMany(orderDetail => orderDetail.OrderDetails)
                                         .WithOne(orderHeader => orderHeader.OrderHeader)
                                         .HasForeignKey(fk => fk.OrderHeaderId)
                                         .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderHeader>().HasOne(ship => ship.Customer)
                                         .WithMany(orderheader => orderheader.OrderHeaders)
                                         .HasForeignKey(fk => fk.CustomerId)
                                         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
