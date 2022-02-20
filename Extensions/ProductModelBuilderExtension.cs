using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class ProductModelBuilderExtension
    {
        public static void ProductOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(pk => pk.Id);

            builder.Entity<Product>().Property(pr => pr.Id)
                                      .HasColumnName("Id")
                                      .HasColumnType("int");

            builder.Entity<Product>().Property(pr => pr.Name)
                                     .HasColumnName("ProductName")
                                     .IsRequired();

            builder.Entity<Product>().Property(pr => pr.Color)
                                     .HasColumnName("Color")
                                     .IsRequired();

            builder.Entity<Product>().Property(pr => pr.Size)
                                     .HasColumnName("Size")
                                     .IsRequired();

            builder.Entity<Product>().Property(pr => pr.UnitPrice)
                                         .HasColumnName("UnitPrice")
                                         .IsRequired();


            builder.Entity<Product>().HasMany(orderDetail => orderDetail.OrderDetails)
                                     .WithOne(p => p.Product)
                                     .HasForeignKey(fk => fk.ProductId)
                                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
