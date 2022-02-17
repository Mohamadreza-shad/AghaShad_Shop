using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class OrderDetailModelBuilderExtension
    {
        public static void OrderDetailOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().ToTable("OrderDetails");
            builder.Entity<OrderDetail>().HasKey(pk => pk.Id);

            builder.Entity<OrderDetail>().Property(pr => pr.Quantity)
                                         .HasColumnName("Quantity")
                                         .HasColumnType("int")
                                         .IsRequired();

            builder.Entity<OrderDetail>().Property(pr => pr.UnitPrice)
                                         .HasColumnName("UnitPrice")
                                         .HasPrecision(2)
                                         .IsRequired();

            builder.Entity<OrderDetail>().Property(pr => pr.TotalPrice)
                                         .HasColumnName("TotalPrice")
                                         .HasPrecision(2)
                                         .IsRequired();

            builder.Entity<OrderDetail>().HasOne(ordHeader => ordHeader.OrderHeader)
                                         .WithMany(ordDetail => ordDetail.OrderDetails)
                                         .HasForeignKey(fk => fk.OrderHeaderId)
                                         .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderDetail>().HasOne(p => p.Product)
                                         .WithMany(orderDetail => orderDetail.OrderDetails)
                                         .HasForeignKey(fk => fk.ProductId)
                                         .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
