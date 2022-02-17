using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class CustomerModelBuilderExtension
    {
        public static void CustomerOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(pk => pk.Id);
            builder.Entity<Customer>().Property(pr => pr.Id)
                                      .HasColumnName("Id")
                                      .HasColumnType("int");

            builder.Entity<Customer>().Property(pr => pr.FullName)
                                      .HasColumnName("FullName")
                                      .IsRequired();

            builder.Entity<Customer>().Property(pr => pr.Phone)
                                      .HasColumnName("Phone")
                                      .HasMaxLength(11)
                                      .IsRequired();

            builder.Entity<Customer>().HasMany(add => add.Addresses)
                                      .WithOne(customer => customer.Customer)
                                      .HasForeignKey(fk => fk.CustomerId)
                                      .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Customer>().HasMany(orderHeader => orderHeader.OrderHeaders)
                                      .WithOne(customer => customer.Customer)
                                      .HasForeignKey(fk => fk.CustomerId)
                                      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
