using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IAddressRepository
    {
        Task InsertAddress(RegisterAddressDto form);
        Task UpdateAddress(int id, RegisterAddressDto form);
        Task DeleteAddress(int id);
        Task<Address> GetAddressById(int id);
        Task<List<Address>> GetAllAddresses();
    }
}
