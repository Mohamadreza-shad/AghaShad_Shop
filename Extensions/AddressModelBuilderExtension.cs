using AghaShad_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Extensions
{
    public static class AddressModelBuilderExtension
    {
        public static void AddressOnModelBuilderExtension(this ModelBuilder builder)
        {
            builder.Entity<Address>().ToTable("Addresses");

            builder.Entity<Address>().HasKey(pk => pk.Id);

            builder.Entity<Address>().Property(pr => pr.City)
                                     .HasColumnName("City")
                                     .IsRequired();

            builder.Entity<Address>().Property(pr => pr.Province)
                                     .HasColumnName("Province")
                                     .IsRequired();

            builder.Entity<Address>().Property(pr => pr.Description)
                                     .HasColumnName("Description")
                                     .IsRequired();

            builder.Entity<Address>().HasOne(customer => customer.Customer)
                                     .WithMany(add => add.Addresses)
                                     .HasForeignKey(fk => fk.CustomerId)
                                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
