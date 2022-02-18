using AghaShad_Shop.Reopository.Implementation;
using AghaShad_Shop.Reopository.Interface;
using AghaShad_Shop.Services.Implementation;
using AghaShad_Shop.Services.Interface;

namespace AghaShad_Shop.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<ICustomerRegisteration, CustomerRegisteration>();
        }
    }
}
