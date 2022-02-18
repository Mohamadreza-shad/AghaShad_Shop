using AghaShad_Shop.DTOs;
using AghaShad_Shop.Models;

namespace AghaShad_Shop.Reopository.Interface
{
    public interface IShippingRepository
    {
        Task InsertShipping(RegisterShippingDto form);
        Task UpdateShipping(int id, RegisterShippingDto form);
        Task DeleteShipping(int id);
        Task<Shipping> GetShippingById(int id);
        Task<Shipping> GetShippingByName(string name);
        Task<List<Shipping>> GetAllShippings();

    }
}
