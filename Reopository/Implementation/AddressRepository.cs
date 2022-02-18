using AghaShad_Shop.DataContext;
using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;
using AghaShad_Shop.Reopository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AghaShad_Shop.Reopository.Implementation
{
    public class AddressRepository : BaseRepository<Address,int>, IAddressRepository
    {
        private readonly ShoppingContext _context;

        public AddressRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteAddress(int id) => await DeleteAndSaveAsync(id);    
        
        public async Task<Address> GetAddressById(int id)
        {
            Address? address = await _context.Address.FirstOrDefaultAsync(add => add.Id == id);
            if (address == null) throw new Exception("Address not Found");

            return address;
        }

        public async Task<List<Address>> GetAllAddresses() => await _context.Address.ToListAsync();

        public async Task InsertAddress(RegisterAddressDto form)
        {
            Address address = new()
            {
                City = form.City,
                CustomerId = form.CustomerId,
                Description = form.Description,
                Province = form.Province
            };

            await AddAndSaveAsync(address);
        }

        public async Task UpdateAddress(int id, RegisterAddressDto form)
        {
            Address? address = await _context.Address.FirstOrDefaultAsync(add => add.Id == id);
            if (address == null) throw new Exception("Address not Found");

            address.City = form.City;   
            address.CustomerId = form.CustomerId;
            address.Description = form.Description; 
            address.Province = form.Province;
            await UpdateAndSaveAsync(address);
        }
    }
}
