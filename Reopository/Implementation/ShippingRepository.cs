using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class ShippingRepository : BaseRepository<Shipping,int>, IShippingRepository
    {
        private readonly ShoppingContext _context;

        public ShippingRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public Task DeleteShipping(int id) => DeleteAndSaveAsync(id);


        public async Task<List<Shipping>> GetAllShippings() => await _context.Shippings.ToListAsync();
        

        public async Task<Shipping> GetShippingById(int id)
        {
            Shipping? shipping = await _context.Shippings.FirstOrDefaultAsync(shipp => shipp.Id == id);
            if (shipping == null) throw new Exception("Shipping not found");

            return shipping;
        }

        public async Task<Shipping> GetShippingByName(string name)
        {
            Shipping? shipping = await _context.Shippings.FirstOrDefaultAsync(shipp => shipp.Name == name);
            if (shipping == null) throw new Exception("Shipping not found");

            return shipping;
        }

        public async Task InsertShipping(RegisterShippingForm form)
        {
            Shipping shipping = new()
            {
                Name = form.Name
            };

            await AddAndSaveAsync(shipping);  
        }

        public async Task UpdateShipping(int id, RegisterShippingForm form)
        {
            Shipping? shipping = await _context.Shippings.FirstOrDefaultAsync(shipp => shipp.Id == id);
            if (shipping == null) throw new Exception("Shipping not found");

            shipping.Name = form.Name;
            await UpdateAndSaveAsync(shipping);
        }
    }
}
