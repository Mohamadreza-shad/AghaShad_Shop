using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IAddressRepository
    {
        Task InsertAddress(RegisterAddressDto form);
        Task UpdateAddress(int customerId, RegisterAddressDto form);
        Task DeleteAddress(int customerId);
        Task<Address> GetAddressById(int customerId);
        Task<List<Address>> GetAllAddresses();
    }
}
